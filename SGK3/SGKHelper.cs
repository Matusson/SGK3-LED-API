using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK3
{
    public static class SGKHelper
    {
        public static uint Vendor = 0x0c45;
        public static uint Product = 0x8513;
        public static uint BufferSize = 64;

        public static byte Prefix = 0x04;

        /// <summary>
        /// Pads the array to expected buffer size.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] PadWithZeroes(byte[] bytes)
        {
            byte[] result = new byte[BufferSize + 1];

            for (int i = 0; i <= BufferSize; i++)
            {
                result[i] = 0x00;
            }

            Array.Copy(bytes, result, bytes.Length);

            return result;
        }
    }
}
