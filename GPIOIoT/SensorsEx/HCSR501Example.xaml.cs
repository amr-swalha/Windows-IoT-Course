using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using IoTHelpers.Boards;
using IoTHelpers.Gpio.Modules;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GPIOIoT.SensorsEx
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HCSR501Example : Page
    {
        private Sr501PirMotionDetector pir;
        public HCSR501Example()
        {
            this.InitializeComponent();

            pir = new Sr501PirMotionDetector(pinNumber: 27);
            pir.RaiseEventsOnUIThread = true;
            pir.MotionDetected += pir_MotionDetected;
            pir.MotionStopped += pir_MotionStopped;
        }
        private void pir_MotionDetected(object sender, EventArgs e)
        {
            // Starts the alarm.
            textBlock.Text = "Motion detected";

        }

        private void pir_MotionStopped(object sender, EventArgs e)
        {
            // Stops the alarm.
            textBlock.Text = "Motion stopped";
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var board = RaspberryPi2Board.GetDefault();
            if (board != null)
            {
                board.PowerLed.TurnOff();
                board.StatusLed.TurnOn();
            }

            base.OnNavigatedTo(e);
        }
        private void MainPage_Unloaded(object sender, RoutedEventArgs e)
        {
            // Cleanup.
            if (pir != null)
            {
                pir.MotionDetected -= pir_MotionDetected;
                pir.MotionStopped -= pir_MotionStopped;
                pir.Dispose();
            }


        }
    }
}
