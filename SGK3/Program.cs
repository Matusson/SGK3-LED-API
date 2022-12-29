using Device.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Hid.Net.Windows;
using System.Linq;
using System.Threading.Tasks;
using Usb.Net.Windows;
using System.Reflection.Emit;
using System.Net.Mail;
using SGK3;

internal class Program
{
    static Dictionary<string, byte[]> keycodes = new(){
            { "esc"     , new byte[3] {0x15, 0x00, 0x02} },
    { "f1"      , new byte[3] { 0x18, 0x03, 0x02 }},
    { "f2"      , new byte[3] { 0x1b, 0x06, 0x02 }},
    { "f3"      , new byte[3] { 0x1e, 0x09, 0x02 }},
    { "f4"      , new byte[3] { 0x21, 0x0c, 0x02 }},
    { "f5"      , new byte[3] { 0x24, 0x0f, 0x02 }},
    { "f6"      , new byte[3] { 0x27, 0x12, 0x02 }},
    { "f7"      , new byte[3] { 0x2a, 0x15, 0x02 }},
    { "f8"      , new byte[3] { 0x2d, 0x18, 0x02 }},
    { "f9"      , new byte[3] { 0x30, 0x1b, 0x02 }},
    { "f10"     , new byte[3] { 0x33, 0x1e, 0x02 }},
    { "f11"     , new byte[3] { 0x36, 0x21, 0x02 }},
    { "f12"     , new byte[3] { 0x39, 0x24, 0x02 }},
    { "up"      , new byte[3] { 0x3f, 0x29, 0x03 }},
    { "prtscr"  , new byte[3] { 0x3f, 0x2a, 0x02 }},
    { "scroll"  , new byte[3] { 0x42, 0x2d, 0x02 }},
    { "num1"    , new byte[3] { 0x45, 0x2f, 0x03 }},
    { "pause"   , new byte[3] { 0x45, 0x30, 0x02 }},
    { "num2"    , new byte[3] { 0x48, 0x32, 0x03 }},
    { "num3"    , new byte[3] { 0x4b, 0x35, 0x03 }},
    { "nument"  , new byte[3] { 0x4e, 0x38, 0x03 }},
    { "grave"   , new byte[3] { 0x54, 0x3f, 0x02 }},
    { "1"       , new byte[3] { 0x57, 0x42, 0x02 }},
    { "2"       , new byte[3] { 0x5a, 0x45, 0x02 }},
    { "3"       , new byte[3] { 0x5d, 0x48, 0x02 }},
    { "4"       , new byte[3] { 0x60, 0x4b, 0x02 }},
    { "5"       , new byte[3] { 0x63, 0x4e, 0x02 }},
    { "6"       , new byte[3] { 0x66, 0x51, 0x02 }},
    { "7"       , new byte[3] { 0x69, 0x54, 0x02 }},
    { "8"       , new byte[3] { 0x6c, 0x57, 0x02 }},
    { "9"       , new byte[3] { 0x6f, 0x5a, 0x02 }},
    { "0"       , new byte[3] { 0x72, 0x5d, 0x02 }},
    { "minus"   , new byte[3] { 0x75, 0x60, 0x02 }},
    { "equal"   , new byte[3] { 0x78, 0x63, 0x02 }},
    { "left"    , new byte[3] { 0x7b, 0x65, 0x03 }},
    { "bckspc"  , new byte[3] { 0x7b, 0x66, 0x02 }},
    { "down"    , new byte[3] { 0x7e, 0x68, 0x03 }},
    { "right"   , new byte[3] { 0x81, 0x6b, 0x03 }},
    { "insert"  , new byte[3] { 0x7e, 0x69, 0x02 }},
    { "home"    , new byte[3] { 0x81, 0x6c, 0x02 }},
    { "pgup"    , new byte[3] { 0x84, 0x6f, 0x02 }},
    { "num0"    , new byte[3] { 0x87, 0x71, 0x03 }},
    { "numlck"  , new byte[3] { 0x87, 0x72, 0x02 }},
    { "numdel"  , new byte[3] { 0x8a, 0x74, 0x03 }},
    { "numslash", new byte[3] { 0x8a, 0x75, 0x02 }},
    { "nummulti", new byte[3] { 0x8d, 0x78, 0x02 }},
    { "numminus", new byte[3] { 0x90, 0x7b, 0x02 }},
    { "tab"     , new byte[3] { 0x93, 0x7e, 0x02 }},
    { "q"       , new byte[3] { 0x96, 0x81, 0x02 }},
    { "w"       , new byte[3] { 0x99, 0x84, 0x02 }},
    { "e"       , new byte[3] { 0x9c, 0x87, 0x02 }},
    { "r"       , new byte[3] { 0x9f, 0x8a, 0x02 }},
    { "t"       , new byte[3] { 0xa2, 0x8d, 0x02 }},
    { "y"       , new byte[3] { 0xa5, 0x90, 0x02 }},
    { "u"       , new byte[3] { 0xa8, 0x93, 0x02 }},
    { "i"       , new byte[3] { 0xab, 0x96, 0x02 }},
    { "o"       , new byte[3] { 0xae, 0x99, 0x02 }},
    { "p"       , new byte[3] { 0xb1, 0x9c, 0x02 }},
    { "lbracket", new byte[3] { 0xb4, 0x9f, 0x02 }},
    { "rbracket", new byte[3] { 0xb7, 0xa2, 0x02 }},
    { "bckslash", new byte[3] { 0xba, 0xa5, 0x02 }},
    { "delete"  , new byte[3] { 0xbd, 0xa8, 0x02 }},
    { "end"     , new byte[3] { 0xc0, 0xab, 0x02 }},
    { "pgdn"    , new byte[3] { 0xc3, 0xae, 0x02 }},
    { "num7"    , new byte[3] { 0xc6, 0xb1, 0x02 }},
    { "num8"    , new byte[3] { 0xc9, 0xb4, 0x02 }},
    { "num9"    , new byte[3] { 0xcc, 0xb7, 0x02 }},
    { "numplus" , new byte[3] { 0xcf, 0xba, 0x02 }},
    { "caps"    , new byte[3] { 0xd2, 0xbd, 0x02 }},
    { "a"       , new byte[3] { 0xd5, 0xc0, 0x02 }},
    { "s"       , new byte[3] { 0xd8, 0xc3, 0x02 }},
    { "d"       , new byte[3] { 0xdb, 0xc6, 0x02 }},
    { "f"       , new byte[3] { 0xde, 0xc9, 0x02 }},
    { "g"       , new byte[3] { 0xe1, 0xcc, 0x02 }},
    { "h"       , new byte[3] { 0xe4, 0xcf, 0x02 }},
    { "j"       , new byte[3] { 0xe7, 0xd2, 0x02 }},
    { "k"       , new byte[3] { 0xea, 0xd5, 0x02 }},
    { "l"       , new byte[3] { 0xed, 0xd8, 0x02 }},
    { "colon"   , new byte[3] { 0xf0, 0xdb, 0x02 }},
    { "quote"   , new byte[3] { 0xf3, 0xde, 0x02 }},
//  { ""        ,new ibyte3] {0xf6, 0xe1, 0x02}}, #nothing
    { "enter"   , new byte[3] { 0xf9, 0xe4, 0x02 }},
//  { ""        ,new ibyte3] {0xfc, 0xe7, 0x02}}, #nothing
//  { ""        ,new ibyte3] {0xff, 0xea, 0x02}}, #nothing
    { "num4"    , new byte[3] { 0x05, 0xf0, 0x02 }},
    { "num5"    , new byte[3] { 0x08, 0xf3, 0x02 }},
    { "num6"    , new byte[3] { 0x0b, 0xf6, 0x02 }},
//  { ""        ,new ibyte3] {0x0e, 0xf9, 0x02}}, #nothing
    { "lshift"  , new byte[3] { 0x11, 0xfc, 0x02 }},
//  { ""        ,new ibyte3] {0x14, 0xff, 0x02}}, #nothing
    { "z"       , new byte[3] { 0x18, 0x02, 0x03 }},
    { "x"       , new byte[3] { 0x1b, 0x05, 0x03 }},
    { "c"       , new byte[3] { 0x1e, 0x08, 0x03 }},
    { "v"       , new byte[3] { 0x21, 0x0b, 0x03 }},
    { "b"       , new byte[3] { 0x24, 0x0e, 0x03 }},
    { "n"       , new byte[3] { 0x27, 0x11, 0x03 }},
    { "m"       , new byte[3] { 0x2a, 0x14, 0x03 }},
    { "comma"   , new byte[3] { 0x2d, 0x17, 0x03 }},
    { "period"  , new byte[3] { 0x30, 0x1a, 0x03 }},
    { "slash"   , new byte[3] { 0x33, 0x1d, 0x03 }},
//  { ""        ,new ibyte3] {0x36, 0x20, 0x02}}, #f10/f11
    { "rshift"  , new byte[3] { 0x39, 0x23, 0x03 }},
//  { ""        ,new ibyte3] {0x3c, 0x26, 0x02}}, #f12
    { "lctrl"   , new byte[3] { 0x51, 0x3b, 0x03 }},
    { "lsuper"  , new byte[3] { 0x54, 0x3e, 0x03 }},
    { "lalt"    , new byte[3] { 0x57, 0x41, 0x03 }},
    { "space"   , new byte[3] { 0x5a, 0x44, 0x03 }},
    { "ralt"    , new byte[3] { 0x5d, 0x47, 0x03 }},
    { "rsuper"  , new byte[3] { 0x60, 0x4a, 0x03 }},
    { "menu"    , new byte[3] { 0x63, 0x4d, 0x03 }},
//  { ""        ,new ibyte3] {0x66, 0x50, 0x02}}, #5/6
    { "rctrl"   , new byte[3] { 0x69, 0x53, 0x03 } }
    };


    private static void Main(string[] args)
    {
        Initialize().GetAwaiter().GetResult();
    }
    private static async Task Initialize()
    {
        var loggerFactory = LoggerFactory.Create((builder) =>
        {
            _ = builder.AddDebug();
        });

        var hidFactory = new FilterDeviceDefinition(vendorId: SGKHelper.Vendor, productId: SGKHelper.Product).CreateWindowsHidDeviceFactory(loggerFactory);

        //Register the factory for creating Usb devices.
        var usbFactory = new FilterDeviceDefinition(vendorId: SGKHelper.Vendor, productId: SGKHelper.Product).CreateWindowsUsbDeviceFactory(loggerFactory);
        var factories = hidFactory.Aggregate(usbFactory);

        var deviceDefinitions = await factories.GetConnectedDeviceDefinitionsAsync();

        //Correct device has 64 byte buffers
        var correctDef = deviceDefinitions.Where(x => x.WriteBufferSize == SGKHelper.BufferSize).FirstOrDefault();

        if (correctDef == null)
        {
            Console.WriteLine("No device");
            return;
        }

        var device = await hidFactory.GetDeviceAsync(correctDef);
        ComManager.Device = device;
        await device.InitializeAsync();

        await BrightnessManager.SetBrightnessLevel(0);
        await Task.Delay(500);

        await BrightnessManager.SetBrightnessLevel(1);
        await Task.Delay(500);

        await BrightnessManager.SetBrightnessLevel(2);
        await Task.Delay(500);

        await BrightnessManager.SetBrightnessLevel(3);
        await Task.Delay(500);

        await BrightnessManager.SetBrightnessLevel(4);
        await Task.Delay(500);

        await BrightnessManager.SetBrightnessLevel(5);
        await Task.Delay(500);

        device.Dispose();
    }
}