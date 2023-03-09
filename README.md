# About
This library is a C# API that allows controlling the LEDs in the Sharkoon Skiller Mech SGK3 keyboard. You can set the color of each key, as well as control the brightness. It was created by listening to communication made by the official software for this keyboard.

## Usage
```cs
using SGK3LEDAPI;

// Initialize before you use any SGK3LEDAPI functionality
// To make sure it works, set the keyboard to the 1st customization profile.
await DeviceDiscoveryManager.AutoInitialize();

// Set color of keys
await KeyManager.SetKeyColor(Key.Enter, Color.Blue);
await KeyManager.SetKeyColor(Key.Space, Color.DarkRed);

// Set brightness level of the board, from range 0-5
await BrightnessManager.SetBrightnessLevel(5);

// Dispose of the keyboard when no longer needed
DeviceDiscoveryManager.DisposeDevice();
```

## Limitations
Unfortunately, you will not be able to create custom animated effects. The keyboard was not designed with this in mind, as it causes a short flash with every key change. Additionally, updating every key on the board takes quite a bit of time. Tested only on Windows.

## Credits
[Venom668/sgk3rgb](https://github.com/Venom668/sgk3rgb) - This project was very useful in figuring out the method, but my key codes (as well as some constant byte values) were different. There might be some hardware differences between the keyboards.
