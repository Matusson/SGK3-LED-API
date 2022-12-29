namespace SGK3
{
    internal static class SGKHelper
    {
        internal const uint Vendor = 0x0c45;
        internal const uint Product = 0x8513;
        internal const uint BufferSize = 64;

        internal const byte Prefix = 0x04;

        /// <summary>
        /// Pads the array to expected buffer size.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        internal static byte[] PadWithZeroes(byte[] bytes)
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
