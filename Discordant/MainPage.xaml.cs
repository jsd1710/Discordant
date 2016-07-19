using Discordant.src.Authentication;
using Discordant.src.HTTP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Discordant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        HTTPSingleton http;

        public MainPage()
        {
            this.InitializeComponent();
            http = HTTPSingleton.Instance;
        }

        private async void testButton_Click(object sender, RoutedEventArgs e)
        {
            MainTest.Text = MainTest.Text + "1";
            string user_token = await Authentication.login(email_textbox.Text, passwordBox.Password);
            MainTest.Text = await http.HttpPost("auth/login", user_token);
        }

        private async void passwordBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.ToString() == "Enter")
            {
                string user_token = await Authentication.login(email_textbox.Text, passwordBox.Password);
                MainTest.Text = await http.HttpPost("auth/login", user_token);
            }
        }
    }
}
