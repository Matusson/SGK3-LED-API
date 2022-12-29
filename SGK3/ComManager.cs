using Device.Net;

namespace SGK3LEDAPI
{
    internal static class ComManager
    {
        internal static IDevice Device { get; set; }

        /// <summary>
        /// Sends specified data to the keyboard.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="longFlash"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal static async Task Send(byte[] data, bool longFlash = false)
        {
            if (Device == null)
                throw new Exception("No device connected! Use DeviceDiscoveryManager to initialize first.");

            // Open signal, causes the long flash
            if (longFlash)
            {
                byte[] __open = new byte[4] { 0x04, 0x01, 0x00, 0x01 };
                await PadAndSend(__open);
            }

            // Data
            await PadAndSend(data);

            byte[] __close = new byte[4] { 0x04, 0x02, 0x00, 0x02 };
            await PadAndSend(__close);
        }

        private static Task PadAndSend(byte[] data)
        {
            data = SGKHelper.PadWithZeroes(data);
            return Device.WriteAndReadAsync(data);
        }
    }
}
