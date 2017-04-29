using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using IoTHelpers.Gpio.Modules;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GPIOIoT.SensorsEx
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ActiveBuzzerExample : Page
    {
        private ActiveBuzzer buzzer;
        public ActiveBuzzerExample()
        {
            this.InitializeComponent();
            buzzer = new ActiveBuzzer(27);
        }

        private async void BtnSwitch_OnClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                txtstatus.Text = "Status is on: " + buzzer.IsOn;
                await Task.Delay(TimeSpan.FromSeconds(1));
                buzzer.Toogle();
            }
        }
    }
}
