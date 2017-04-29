using Windows.Devices.Gpio;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GPIOIoT.SensorsEx;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GPIOIoT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private GpioPin pin;
        
        public MainPage()
        {
            this.InitializeComponent();
            //GpioController controller = GpioController.GetDefault();
            //pin = controller.OpenPin(4);
            //pin.SetDriveMode(GpioPinDriveMode.Output);
            //pin.Write(GpioPinValue.High);
            

        }

       

       

        private void BtnDH11_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DH11Example), null);
        }

        private void BtnSR501_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HCSR501Example), null);
        }

        private async void ActiveBuz_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ActiveBuzzerExample), null);
        }

        private void VibExample_OnClick(object sender, RoutedEventArgs e)
        {
             this.Frame.Navigate(typeof(VibrationExample), null);
        }
    }
}

