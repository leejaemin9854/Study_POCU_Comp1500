using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab11
{
    public static class Encoder
    {
        public static bool TryEncode(Stream input, Stream output)
        {
            if (input == null) 
            {
                return false;
            }
            if (input.Length == 0)
            {
                output.SetLength(0);
                return false;
            }


            byte[] bytes = new byte[input.Length];

            input.Read(bytes, 0, bytes.Length);

            int num = 0;
            byte ch = bytes[0];

            int seek = 0;
            while (seek < bytes.Length)
            {
                if (ch != bytes[seek] || num == 255) 
                {
                    output.WriteByte((byte)num);
                    output.WriteByte((byte)ch);

                    num = 1;
                    ch = bytes[seek];
                }
                else
                {
                    num++;
                }

                seek++;
            }
            output.WriteByte((byte)num);
            output.WriteByte((byte)ch);


            return true;
        }

        public static bool TryDecode(Stream input, Stream output)
        {
            if (input == null)
            {
                return false;
            }
            if (input.Length == 0)
            {
                output.SetLength(0);
                return false;
            }

            for (int i = 0; i < input.Length / 2; i++) 
            {
                int cnt = input.ReadByte();
                byte b = (byte)input.ReadByte();

                for (int num = 0; num < cnt; num++)
                {
                    output.WriteByte(b);
                    Console.Write((char)b);
                }


            }



            return true;
        }
    }
}

