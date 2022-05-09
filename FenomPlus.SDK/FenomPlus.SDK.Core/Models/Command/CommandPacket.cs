using System;
namespace FenomPlus.SDK.Core.Models.Command
{
    public class CommandPacket : BasePacket
    {
        const int MAX_PACKET_PAYLOAD_SIZE = 64;
        const int MIN_PACKET_PAYLOAD_SIZE = 11;             // 1 preamble + 5 header + 0 payload + 2 crc + 1 postamble
        const int PREAMBLE = 0xAA;
        const int POSTAMBLE = 0x55;

        // 2 preable
        // 1 command
        // 2 page = 0xffff last page or only packet
        // 1 size of data
        // 1 status
        // ? data
        // 2 crc
        // 2 postable
        const byte PREAMBLE_LEN = 1;
        const byte COMMAND_LEN = 1;
        const byte PAGE_LEN = 2;
        const byte SIZE_LEN = 1;
        const byte STATUS_LEN = 1;
        const byte PAYLOAD_LEN = 0;
        const byte CHECKSUM_LEN = 2;
        const byte POSTABLE_LEN = 1;

        //
        const byte PREAMBLE_INDEX   = 0x00;                                 // 2
        const byte COMMAND_INDEX    = PREAMBLE_INDEX + PREAMBLE_LEN;        // 1
        const byte PAGE_INDEX       = COMMAND_INDEX + COMMAND_LEN;          // 1
        const byte SIZE_INDEX       = PAGE_INDEX + PAGE_LEN;                // 2
        const byte STATUS_INDEX     = SIZE_INDEX + SIZE_LEN;                // 1
        const byte PAYLOAD_INDEX    = STATUS_INDEX + STATUS_LEN;            // ?
        const byte CHECKSUM_INDEX   = PAYLOAD_INDEX + PAYLOAD_LEN;          // 4
        const byte POSTABLE_INDEX = CHECKSUM_INDEX + CHECKSUM_LEN;          // 2


        public byte command { get; set; }
        public int  page { get; set; }
        public byte size { get; set; }
        public byte status { get; set; }
        public byte[] payload { get; set; }
        public int checksum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public CommandPacket(byte[] data)
        {
            if (data == null) return;
            if (data.Length < MIN_PACKET_PAYLOAD_SIZE) return;
            if (Extract8(data,PREAMBLE_INDEX) != PREAMBLE) return;              // must start with 
            if (Extract8(data,data.Length - CHECKSUM_LEN) != POSTAMBLE) return; // must end with
            Data = data;                                                        // store orignal here

            command = Extract8(data, COMMAND_INDEX);                            // extract command here
            page = Extract16(data, PAGE_INDEX);                                 // extract page
            size = Extract8(data, SIZE_INDEX);                                  // extract size
            status = Extract8(data, STATUS_INDEX);                              // extract size

            // extract checksum here
            checksum = Extract32(data, data.Length - CHECKSUM_LEN);             // checksum at the end

            int payloadLen = Data.Length - MIN_PACKET_PAYLOAD_SIZE;
            if ((size <= payloadLen) && (payloadLen > 0))
            {
                payload = new byte[payloadLen];
                Array.Copy(data, PAYLOAD_INDEX, payload, 0, payloadLen);
            }

            // calcuate checkcum here

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int CalculateChecksum()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static CommandPacket Decode(byte[] data)
        {
            return new CommandPacket(data);
        }
    }
}