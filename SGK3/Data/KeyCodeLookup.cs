namespace SGK3LEDAPI
{
    internal class KeyCodeLookup
    {
        /// <summary>
        /// A list of all physical key codes used for changing light colors, ordered according to the Key enum.
        /// </summary>
        internal readonly static List<byte[]> KeyCodes = new()
        {
            // These are ordered by physical layout from top to bottom, from left to right
            new byte[4]{0x11, 0x03, 0x00, 0x00},  // Top row
            new byte[4]{0x14, 0x03, 0x03, 0x00},
            new byte[4]{0x17, 0x03, 0x06, 0x00},
            new byte[4]{0x1a, 0x03, 0x09, 0x00},
            new byte[4]{0x1d, 0x03, 0x0c, 0x00},
            new byte[4]{0x20, 0x03, 0x0f, 0x00},
            new byte[4]{0x23, 0x03, 0x12, 0x00},
            new byte[4]{0x26, 0x03, 0x15, 0x00},
            new byte[4]{0x29, 0x03, 0x18, 0x00},
            new byte[4]{0x2c, 0x03, 0x1b, 0x00},
            new byte[4]{0x2f, 0x03, 0x1e, 0x00},
            new byte[4]{0x32, 0x03, 0x21, 0x00},
            new byte[4]{0x35, 0x03, 0x24, 0x00},

            new byte[4]{0x3b, 0x03, 0x2a, 0x00},
            new byte[4]{0x3e, 0x03, 0x2d, 0x00},
            new byte[4]{0x41, 0x03, 0x30, 0x00},

            new byte[4]{0x50, 0x03, 0x3f, 0x00},  // 2nd row
            new byte[4]{0x53, 0x03, 0x42, 0x00},
            new byte[4]{0x56, 0x03, 0x45, 0x00},
            new byte[4]{0x59, 0x03, 0x48, 0x00},
            new byte[4]{0x5c, 0x03, 0x4b, 0x00},
            new byte[4]{0x5f, 0x03, 0x4e, 0x00},
            new byte[4]{0x62, 0x03, 0x51, 0x00},
            new byte[4]{0x65, 0x03, 0x54, 0x00},
            new byte[4]{0x68, 0x03, 0x57, 0x00},
            new byte[4]{0x6b, 0x03, 0x5a, 0x00},
            new byte[4]{0x6e, 0x03, 0x5d, 0x00},
            new byte[4]{0x71, 0x03, 0x60, 0x00},
            new byte[4]{0x74, 0x03, 0x63, 0x00},
            new byte[4]{0x77, 0x03, 0x66, 0x00},

            new byte[4]{0x7a, 0x03, 0x69, 0x00},
            new byte[4]{0x7d, 0x03, 0x6c, 0x00},
            new byte[4]{0x80, 0x03, 0x6f, 0x00},

            new byte[4]{0x83, 0x03, 0x72, 0x00},  // Top numpad row
            new byte[4]{0x86, 0x03, 0x75, 0x00},
            new byte[4]{0x89, 0x03, 0x78, 0x00},
            new byte[4]{0x8c, 0x03, 0x7b, 0x00},

            new byte[4]{0x8f, 0x03, 0x7e, 0x00},  // 3rd row
            new byte[4]{0x92, 0x03, 0x81, 0x00},
            new byte[4]{0x95, 0x03, 0x84, 0x00},
            new byte[4]{0x98, 0x03, 0x87, 0x00},
            new byte[4]{0x9b, 0x03, 0x8a, 0x00},
            new byte[4]{0x9e, 0x03, 0x8d, 0x00},
            new byte[4]{0xa1, 0x03, 0x90, 0x00},
            new byte[4]{0xa4, 0x03, 0x93, 0x00},
            new byte[4]{0xa7, 0x03, 0x96, 0x00},
            new byte[4]{0xaa, 0x03, 0x99, 0x00},
            new byte[4]{0xad, 0x03, 0x9c, 0x00},
            new byte[4]{0xb0, 0x03, 0x9f, 0x00},
            new byte[4]{0xb3, 0x03, 0xa2, 0x00},
            new byte[4]{0xb6, 0x03, 0xa5, 0x00},

            new byte[4]{0xb9, 0x03, 0xa8, 0x00},
            new byte[4]{0xbc, 0x03, 0xab, 0x00},
            new byte[4]{0xbf, 0x03, 0xae, 0x00},

            new byte[4]{0xc2, 0x03, 0xb1, 0x00},  // 2nd numpad row
            new byte[4]{0xc5, 0x03, 0xb4, 0x00},
            new byte[4]{0xc8, 0x03, 0xb7, 0x00},
            new byte[4]{0xcb, 0x03, 0xba, 0x00},

            new byte[4]{0xce, 0x03, 0xbd, 0x00},  // 4th row
            new byte[4]{0xd1, 0x03, 0xc0, 0x00},
            new byte[4]{0xd4, 0x03, 0xc3, 0x00},
            new byte[4]{0xd7, 0x03, 0xc6, 0x00},
            new byte[4]{0xda, 0x03, 0xc9, 0x00},
            new byte[4]{0xdd, 0x03, 0xcc, 0x00},
            new byte[4]{0xe0, 0x03, 0xcf, 0x00},
            new byte[4]{0xe3, 0x03, 0xd2, 0x00},
            new byte[4]{0xe6, 0x03, 0xd5, 0x00},
            new byte[4]{0xe9, 0x03, 0xd8, 0x00},
            new byte[4]{0xec, 0x03, 0xdb, 0x00},
            new byte[4]{0xef, 0x03, 0xde, 0x00},
            new byte[4]{0xf5, 0x03, 0xe4, 0x00},

            new byte[4]{0x01, 0x04, 0xf0, 0x00},  // 3rd numpad row
            new byte[4]{0x04, 0x04, 0xf3, 0x00},
            new byte[4]{0x07, 0x04, 0xf6, 0x00},

            new byte[4]{0x03, 0x03, 0xfc, 0x00},  // 5th row
            new byte[4]{0x15, 0x02, 0x02, 0x01},
            new byte[4]{0x18, 0x02, 0x05, 0x01},
            new byte[4]{0x1b, 0x02, 0x08, 0x01},
            new byte[4]{0x1e, 0x02, 0x0b, 0x01},
            new byte[4]{0x21, 0x02, 0x0e, 0x01},
            new byte[4]{0x24, 0x02, 0x11, 0x01},
            new byte[4]{0x27, 0x02, 0x14, 0x01},
            new byte[4]{0x2a, 0x02, 0x17, 0x01},
            new byte[4]{0x2d, 0x02, 0x1a, 0x01},
            new byte[4]{0x30, 0x02, 0x1d, 0x01},
            new byte[4]{0x36, 0x02, 0x23, 0x01},

            new byte[4]{0x3c, 0x02, 0x29, 0x01},

            new byte[4]{0x42, 0x02, 0x2f, 0x01},  // 4th numpad row
            new byte[4]{0x45, 0x02, 0x32, 0x01},
            new byte[4]{0x48, 0x02, 0x35, 0x01},
            new byte[4]{0x4b, 0x02, 0x38, 0x01},

            new byte[4]{0x4e, 0x02, 0x3b, 0x01},  // Bottom row
            new byte[4]{0x51, 0x02, 0x3e, 0x01},
            new byte[4]{0x54, 0x02, 0x41, 0x01},
            new byte[4]{0x57, 0x02, 0x44, 0x01},
            new byte[4]{0x5a, 0x02, 0x47, 0x01},
            new byte[4]{0x5d, 0x02, 0x4a, 0x01},
            new byte[4]{0x60, 0x02, 0x4d, 0x01},
            new byte[4]{0x66, 0x02, 0x53, 0x01},

            new byte[4]{0x78, 0x02, 0x65, 0x01},
            new byte[4]{0x7b, 0x02, 0x68, 0x01},
            new byte[4]{0x7e, 0x02, 0x6b, 0x01},

            new byte[4]{0x84, 0x02, 0x71, 0x01},  // Bottom numpad row
            new byte[4]{0x87, 0x02, 0x74, 0x01},
        };
    }
}
