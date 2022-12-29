namespace SGK3LEDAPI
{
    /// <summary>
    /// Allows general brightness control.
    /// </summary>
    public static class BrightnessManager
    {
        private static readonly List<byte[]> _brightnessCodes = new()
        {
            { new byte[2]{0x08, 0x00} }, // 6 brightness levels, including 0
            { new byte[2]{0x09, 0x01} },
            { new byte[2]{0x0a, 0x02} },
            { new byte[2]{0x0b, 0x03} },
            { new byte[2]{0x0c, 0x04} },
            { new byte[2]{0x0d, 0x05} }
        };

        /// <summary>
        /// Sets the brightness level of they keyboard.
        /// </summary>
        /// <param name="level"> Level of brightness, valid range 0-5. </param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown if <paramref name="level"/> is not between 0 and 5. </exception>
        public static Task SetBrightnessLevel(int level)
        {
            if (level < 0)
                throw new ArgumentOutOfRangeException(nameof(level), "Brightness may not be negative.");

            if (level > 5)
                throw new ArgumentOutOfRangeException(nameof(level), "Max brightness level is 5.");


            List<byte> message = new();
            message.Add(SGKHelper.Prefix);
            message.Add(_brightnessCodes[level][0]);

            message.AddRange(new byte[] {0x00, 0x06, 0x01, 0x01, 0x00, 0x00});

            message.Add(_brightnessCodes[level][1]);


            return ComManager.Send(message.ToArray());
        }
    }
}
