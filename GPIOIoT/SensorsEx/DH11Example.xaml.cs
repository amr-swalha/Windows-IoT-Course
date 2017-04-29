using System;
using Windows.UI.Xaml.Controls;
using IoTHelpers.Gpio.Modules;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GPIOIoT.SensorsEx
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DH11Example : Page
    {
        private readonly Dht11HumitureSensor humitureSensor;
        public DH11Example()
        {
            this.InitializeComponent();
            Unloaded += MainPage_Unloaded;
            humitureSensor = new Dht11HumitureSensor(pinNumber: 27);
            humitureSensor.RaiseEventsOnUIThread = true;
            humitureSensor.ReadingChanged += HumitureSensor_ReadingChanged;
        }
        private void MainPage_Unloaded(object sender, object args)
        {
            if (humitureSensor != null)
            {
                humitureSensor.ReadingChanged -= HumitureSensor_ReadingChanged;
                humitureSensor.Dispose();
            }
        }
        private void HumitureSensor_ReadingChanged(object sender, EventArgs e)
        {
            var temperature = humitureSensor.CurrentTemperature;
            var humidity = humitureSensor.CurrentHumidity;

            textBlock.Text = $"{temperature}°C";
            textBlock3.Text = $"{humidity}%";
        }
    }
}
