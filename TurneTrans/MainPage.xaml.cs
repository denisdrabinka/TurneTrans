using System.Net;

namespace TurneTrans
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private string _deviceToken;

        public MainPage()
        {
            InitializeComponent();
            var cookies = new CookieContainer();
            var uri = new Uri("https://ext-dev.online.turne-trans.ru");
            cookies.Add(new Cookie { Name = "login", Value = "schetDrevnihShizov@shueppsh.pulushka", Domain = uri.Host, Path = "/" });
            cookies.Add(new Cookie { Name = "password", Value = "Nmwp7TGB", Domain = uri.Host, Path = "/" });

            myWebView.Cookies = cookies;
            myWebView.Source = new UrlWebViewSource { Url = "https://ext-dev.online.turne-trans.ru" };

            if (Preferences.ContainsKey("DeviceToken"))
            {
                _deviceToken = Preferences.Get("DeviceToken", "");
            }
        }

        private void OnNavigating(object sender, WebNavigatingEventArgs e)
        {

        }
    }
}
