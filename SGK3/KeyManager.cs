using System.Drawing;

namespace SGK3
{
    public static class KeyManager
    {
        public static Task SetKeyColor(Key keyId, Color color)
        {
            List<byte> data = new();
            data.Add(SGKHelper.Prefix);
            data.Add(KeyCodeLookup.KeyCodes[(int)keyId][0]);
            data.Add(KeyCodeLookup.KeyCodes[(int)keyId][1]);

            data.AddRange(new byte[] { 0x11, 0x03 });

            data.Add(KeyCodeLookup.KeyCodes[(int)keyId][2]);
            data.Add(KeyCodeLookup.KeyCodes[(int)keyId][3]);

            data.Add(0x01);

            data.Add(color.R);
            data.Add(color.G);
            data.Add(color.B);

            return ComManager.Send(data.ToArray());
        }
    }
}
