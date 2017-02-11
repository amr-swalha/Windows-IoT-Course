using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FrontRP.API
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VisitorsPage : Page
    {
        public VisitorsPage()
        {
            this.InitializeComponent();
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var request = client.PostAsync("http://192.168.1.13/RPIoT/api/values?Name=" + VisitorName.Text + "&DateOfVisit=" + DoV.Date.ToString("yyyy-MM-dd") + "&Note=" + Note.Text, null).Result;
            txtResult.Text = "Result: " + request.Content.ReadAsStringAsync().Result.ToString() + " at: " + DateTime.Now;
        }
    }
}
