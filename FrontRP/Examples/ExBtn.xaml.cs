using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace FrontRP.Examples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExBtn : Page
    {
        public ExBtn()
        {
            this.InitializeComponent();
        }

        private void BtnMain_OnClick(object sender, RoutedEventArgs e)
        {
            /*
             When the button is pressed
            */
        }

        private void BtnMain_OnGotFocus(object sender, RoutedEventArgs e)
        {
            /*When the button is on foucs*/
        }

        private void BtnMain_OnLostFocus(object sender, RoutedEventArgs e)
        {
            /*When the button is of foucs*/
        }
    }
}
