using Device.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK3
{
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


        public static async Task SetBrightnessLevel(int level)
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

            await ComManager.Send(message.ToArray());
        }
    }
}
