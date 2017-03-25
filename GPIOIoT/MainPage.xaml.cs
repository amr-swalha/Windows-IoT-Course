using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GPIOIoT.SensorsEx;
using IoTHelpers;
using IoTHelpers.Boards;
using IoTHelpers.Gpio;
using IoTHelpers.Gpio.Modules;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GPIOIoT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
            
            
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

