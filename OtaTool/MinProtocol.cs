using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MinProtocol
{
    enum minState
    {
        SEARCHING_FOR_SOF,
        RECEIVING_ID_CONTROL,
        RECEIVING_SEQ,
        RECEIVING_LENGTH,
        RECEIVING_PAYLOAD,
        RECEIVING_CHECKSUM_3,
        RECEIVING_CHECKSUM_2,
        RECEIVING_CHECKSUM_1,
        RECEIVING_CHECKSUM_0,
        RECEIVING_EOF
    };

    enum minSpecialByte
{
        HEADER_BYTE = 0xAA,
        STUFF_BYTE = 0x55,
        EOF_BYTE = 0x55,
    };

    public struct minFrame
    {
        public byte[] payload;
        public int size;
        public byte id;
    }

    public class Min
    {
        // min_frame_cfg_t* callback;
        public byte[] rx_frame_payload_buf = new byte[255];      // Payload received so far
        public UInt32 rx_frame_checksum;         // Checksum received over the wire
        public UInt32 rx_checksum;    // Calculated checksum for receiving frame
        public UInt32 tx_checksum;    // Calculated checksum for sending frame
        public byte rx_header_bytes_seen = 0;       // Countdown of header bytes to reset state
        minState rx_frame_state = minState.SEARCHING_FOR_SOF;             // State of receiver
        byte rx_frame_bytes_count = 0;       // Length of payload received so far
        // byte tx_frame_bytes_count = 0;       // Length of payload received so far
        public byte rx_frame_id_control = 0;        // ID and control bit of frame being received
        public byte rx_frame_seq = 0;               // Sequence number of frame being received
        public byte rx_frame_length = 0;            // Length of frame
        public byte rx_control = 0;                 // Control byte
        public byte tx_header_byte_countdown = 0;   // Count out the header bytes

        public byte min_get_id(byte id_control)
        {
            return (byte)(id_control & 0x3F);
        }

        public int on_wire_size(int len)
        {
            // Number of bytes needed for a frame with a given payload length, excluding stuff bytes
            // 3 header bytes, ID/control byte, length byte, seq byte, 4 byte CRC, EOF byte

            return (len + 11);
        }

        public void crc32_init_context(ref UInt32 crc)
        {
            crc = 0xFFFFFFFFU;
        }

        private void crc32_step(ref UInt32 crc, byte data)
        {
            UInt32 val = 1;
            crc ^= data;
            for (int j = 0; j < 8; j++)
            {
                UInt32 mask = (UInt32) (-(crc & val));
                crc = (crc >> 1) ^ (0xEDB88320U & mask);
            }
        }

        private UInt32 crc32_finalize(UInt32 crc)
        {
            return ~crc;
        }

        private void min_rx_byte(byte data)
        {
            // Regardless of state, three header bytes means "start of frame" and
            // should reset the frame buffer and be ready to receive frame data
            //
            // Two in a row in over the frame means to expect a stuff byte.
            UInt32 crc;

            if (this.rx_header_bytes_seen == 2)
            {
                this.rx_header_bytes_seen = 0;
                if (data == (byte)minSpecialByte.HEADER_BYTE)
                {
                    this.rx_frame_state = minState.RECEIVING_ID_CONTROL;
                    return;
                }
                if (data == (byte)minSpecialByte.STUFF_BYTE)
                {
                    /* Discard this byte; carry on receiving on the next character */
                    return;
                }
                else
                {
                    /* Something has gone wrong, give up on this frame and look for header again */
                    this.rx_frame_state = minState.SEARCHING_FOR_SOF;
                    return;
                }
            }

            if (data == (byte)minSpecialByte.HEADER_BYTE)
            {
                this.rx_header_bytes_seen++;
            }
            else
            {
                this.rx_header_bytes_seen = 0;
            }

            switch (this.rx_frame_state)
            {
                case minState.SEARCHING_FOR_SOF:
                    break;
                case minState.RECEIVING_ID_CONTROL:
                    this.rx_frame_id_control = data;
                    this.rx_frame_bytes_count = 0;
                    crc32_init_context(ref this.rx_checksum);
                    crc32_step(ref this.rx_checksum, data);
                    if ((data & 0x80) != 0)
                    {
                        this.rx_frame_state = minState.SEARCHING_FOR_SOF;
                    }
                    else
                    {
                        this.rx_frame_seq = 0;
                        this.rx_frame_state = minState.RECEIVING_LENGTH;
                    }
                    break;
                case minState.RECEIVING_SEQ:
                    this.rx_frame_seq = data;
                    crc32_step(ref this.rx_checksum, data);
                    this.rx_frame_state = minState.RECEIVING_LENGTH;
                    break;
                case minState.RECEIVING_LENGTH:
                    this.rx_frame_length = data;
                    this.rx_control = data;
                    crc32_step(ref this.rx_checksum, data);
                    if (this.rx_frame_length > 0)
                    {
                        // Can reduce the RAM size by compiling limits to frame sizes
                        if (this.rx_frame_length <= 255)
                        {
                            this.rx_frame_state = minState.RECEIVING_PAYLOAD;
                        }
                        else
                        {
                            // Frame dropped because it's longer than any frame we can buffer
                            this.rx_frame_state = minState.SEARCHING_FOR_SOF;
                        }
                    }
                    else
                    {
                        this.rx_frame_state = minState.RECEIVING_CHECKSUM_3;
                    }
                    break;
                case minState.RECEIVING_PAYLOAD:
                    this.rx_frame_payload_buf[this.rx_frame_bytes_count++] = data;
                    crc32_step(ref this.rx_checksum, data);
                    if (--this.rx_frame_length == 0)
                    {
                        this.rx_frame_state = minState.RECEIVING_CHECKSUM_3;
                    }
                    break;
                case minState.RECEIVING_CHECKSUM_3:
                    this.rx_frame_checksum = ((UInt32)data) << 24;
                    this.rx_frame_state = minState.RECEIVING_CHECKSUM_2;
                    break;
                case minState.RECEIVING_CHECKSUM_2:
                    this.rx_frame_checksum |= ((UInt32)data) << 16;
                    this.rx_frame_state = minState.RECEIVING_CHECKSUM_1;
                    break;
                case minState.RECEIVING_CHECKSUM_1:
                    this.rx_frame_checksum |= ((UInt32)data) << 8;
                    this.rx_frame_state = minState.RECEIVING_CHECKSUM_0;
                    break;
                case minState.RECEIVING_CHECKSUM_0:
                    this.rx_frame_checksum |= data;
                    crc = crc32_finalize(this.rx_checksum);
                    if (this.rx_frame_checksum != crc)
                    {
                        // Frame fails the checksum and so is dropped
                        this.rx_frame_state = minState.SEARCHING_FOR_SOF;
                    }
                    else
                    {
                        // Checksum passes, go on to check for the end-of-frame marker
                        this.rx_frame_state = minState.RECEIVING_EOF;
                    }
                    break;
                case minState.RECEIVING_EOF:
                    if (data == (byte)minSpecialByte.EOF_BYTE)
                    {
                        // Frame received OK, pass up data to handler
                        // valid_frame_received(self);
                        System.Diagnostics.Debug.WriteLine("\r\nValid frame received");

                    }
                    // else discard
                    // Look for next frame */
                    this.rx_frame_state = minState.SEARCHING_FOR_SOF;
                    break;
                default:
                    // Should never get here but in case we do then reset to a safe state
                    this.rx_frame_state = minState.SEARCHING_FOR_SOF;
                    break;
            }
        }
        public void min_rx_feed(byte[] serialData)
        {
            foreach (byte b in serialData)
            {
                min_rx_byte(b);
            }
        }

        private void stuffed_tx_byte(byte data)
        {
            // Transmit the byte
            min_tx_byte(data);
            crc32_step(ref this.tx_checksum, data);

            // See if an additional stuff byte is needed
            if (data == (byte)minSpecialByte.HEADER_BYTE)
            {
                if (--this.tx_header_byte_countdown == 0)
                {
                    min_tx_byte((byte)minSpecialByte.STUFF_BYTE); // Stuff byte
                    this.tx_header_byte_countdown = 2;
                }
            }
            else
            {
                this.tx_header_byte_countdown = 2;
            }
        }

        private UInt32 min_tx_space()
        {
            return 0xFF;
        }

        private void min_tx_byte(byte data)
        {
            // self->callback->tx_byte(self, data);
            // Trace.Write("Exiting Main");
            System.Diagnostics.Debug.Write(data.ToString("X") + " ");
        }

        private void on_wire_bytes(byte id_control,
                                    byte seq,
                                    ref byte[] payload_base,
                                    UInt16 payload_offset,
                                    UInt16 payload_mask,
                                    byte payload_len)
        {
            byte n, i;
            UInt32 checksum;

            this.tx_header_byte_countdown = 2;
            crc32_init_context(ref this.tx_checksum);


            // Header is 3 bytes; because unstuffed will reset receiver immediately
            min_tx_byte((byte)minSpecialByte.HEADER_BYTE);
            min_tx_byte((byte)minSpecialByte.HEADER_BYTE);
            min_tx_byte((byte)minSpecialByte.HEADER_BYTE);

            stuffed_tx_byte(id_control);
            if ((id_control & 0x80) != 0)
            {
                // Send the sequence number if it is a transport frame
                stuffed_tx_byte(seq);
            }

            stuffed_tx_byte(payload_len);

            for (i = 0, n = payload_len; n > 0; n--, i++)
            {
                stuffed_tx_byte(payload_base[payload_offset]);
                payload_offset++;
                payload_offset &= payload_mask;
            }

            checksum = crc32_finalize(this.tx_checksum);

            // Network order is big-endian. A decent C compiler will spot that this
            // is extracting bytes and will use efficient instructions.
            stuffed_tx_byte((byte)((checksum >> 24) & 0xFFU));
            stuffed_tx_byte((byte)((checksum >> 16) & 0xFFU));
            stuffed_tx_byte((byte)((checksum >> 8) & 0xFFU));
            stuffed_tx_byte((byte)((checksum >> 0) & 0xFFU));

            // Ensure end-of-frame doesn't contain 0xaa and confuse search for start-of-frame
            min_tx_byte((byte)minSpecialByte.EOF_BYTE);


            // this.tx_frame_bytes_count = 0;
        }

        // Sends an application MIN frame on the wire (do not put into the transport queue)
        public void min_send_frame(minFrame msg)
        {
            if ((on_wire_size((int)msg.size) <= (int)min_tx_space()))
            {
                on_wire_bytes(min_get_id((byte)msg.id), 0, ref msg.payload, 0, 0xFFFF, (byte)(msg.size & 0xFF));
            }
        }
    }
}
