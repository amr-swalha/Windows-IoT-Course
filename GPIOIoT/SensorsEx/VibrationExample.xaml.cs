using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GPIOIoT.SensorsEx
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VibrationExample : Page
    {
        private GpioPin pin;
        public VibrationExample()
        {
            this.InitializeComponent();
            GpioController controller = GpioController.GetDefault();
            pin = controller.OpenPin(27);
            pin.Write(GpioPinValue.Low);
            pin.SetDriveMode(GpioPinDriveMode.Input);
            pin.DebounceTimeout  = new TimeSpan(0, 0, 0, 0, 20);
            pin.ValueChanged += PinOnValueChanged;
        }

        private void PinOnValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                textBlock.Text = sender.Read().ToString();
            });
        }

        private void VibOn_OnClick(object sender, RoutedEventArgs e)
        {
            GpioController controller = GpioController.GetDefault();
            using (GpioPin pin = controller.OpenPin(27))
            {
                var value = GpioPinValue.High;
                pin.SetDriveMode(GpioPinDriveMode.Input);
                pin.Write(value);
            }
        }
    }
}
