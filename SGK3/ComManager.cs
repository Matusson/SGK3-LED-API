using Device.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK3
{
    public static class ComManager
    {
        public static IDevice Device { get; set; }

        /// <summary>
        /// Sends specified data to the keyboard.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="flash"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task Send(byte[] data, bool flash = false, bool sendClose = true)
        {
            if (Device == null)
                throw new Exception("No device connected!");

            // Open signal, causes the long flash
            if (flash)
            {
                byte[] __open = new byte[4] { 0x04, 0x01, 0x00, 0x01 };
                __open = SGKHelper.PadWithZeroes(__open);
                await Device.WriteAndReadAsync(__open);
            }

            // Data
            data = SGKHelper.PadWithZeroes(data);
            await Device.WriteAndReadAsync(data);

            await SendCloseSignal();
        }

        private static async Task SendCloseSignal()
        {
            byte[] __close = new byte[4] { 0x04, 0x02, 0x00, 0x02 };
            __close = SGKHelper.PadWithZeroes(__close);
            await Device.WriteAndReadAsync(__close);
        }
    }
}
