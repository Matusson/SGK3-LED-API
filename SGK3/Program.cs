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
using System.Drawing;

internal class Program
{



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

        device.Dispose();
    }
}