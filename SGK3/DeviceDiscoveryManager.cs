using Device.Net;
using Hid.Net.Windows;
using Usb.Net.Windows;
using Microsoft.Extensions.Logging;

namespace SGK3
{
    /// <summary>
    /// Handles discovery and initialization of they keyboard device.
    /// </summary>
    public static class DeviceDiscoveryManager
    {
        /// <summary>
        /// Automatically find the Skiller Mech SGK3 device and initialize it.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"> Thrown if device not found. </exception>
        public static async Task AutoInitialize()
        {
            var loggerFactory = LoggerFactory.Create((builder) =>
            {
                _ = builder.AddDebug();
            });

            var hidFactory = new FilterDeviceDefinition(vendorId: SGKHelper.Vendor, productId: SGKHelper.Product).CreateWindowsHidDeviceFactory(loggerFactory);
            var usbFactory = new FilterDeviceDefinition(vendorId: SGKHelper.Vendor, productId: SGKHelper.Product).CreateWindowsUsbDeviceFactory(loggerFactory);
            var factories = hidFactory.Aggregate(usbFactory);

            var deviceDefinitions = await factories.GetConnectedDeviceDefinitionsAsync();

            // Correct device has 64 byte buffers
            var correctDef = deviceDefinitions.Where(x => x.WriteBufferSize == SGKHelper.BufferSize).FirstOrDefault();

            if (correctDef == null)
            {
                throw new Exception("Could not automatically locate the Skiller Mech SGK3 device.");
            }

            var device = await hidFactory.GetDeviceAsync(correctDef);
            await InitializeManual(device);
        }

        /// <summary>
        /// Can be used to manually initialize a device as the SGK3 keyboard, if not possible to AutoInitialize.
        /// </summary>
        /// <param name="keyboardDevice"></param>
        /// <returns></returns>
        public static async Task InitializeManual(IDevice keyboardDevice)
        {
            ComManager.Device = keyboardDevice;
            await keyboardDevice.InitializeAsync();
        }
    }
}
