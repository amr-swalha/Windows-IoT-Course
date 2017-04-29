using System;
using Windows.Devices.Gpio;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
