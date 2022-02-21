using Xamarin.Forms;
using FenomPlus.SDK.Core.Ble.Interface;
using FenomPlus.SDK.Abstractions;
using Xamarin.Essentials;
using Microsoft.Extensions.Logging;
using FenomPlus.SDK.Core;
using FenomPlus.Sandbox.Views;

namespace FenomPlus.Sandbox
{
    public partial class App : Application
    {

        public static ILoggerFactory loggerFactory { get; set; }
        public static IBleDevice BleDevice { get; set; }

        public App()
        {
            InitializeComponent();

            App.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Debug)
                    .AddFilter("FenomPlus", LogLevel.Debug);
            });
            MainPage = new MainPage();
        }

        private static IFenomHubSystemDiscovery fenomHubSystemDiscovery;
        public static IFenomHubSystemDiscovery FenomHubSystemDiscovery {
            get
            {
                if (fenomHubSystemDiscovery == null)
                {
                    fenomHubSystemDiscovery = new FenomHubSystemDiscovery();
                    fenomHubSystemDiscovery.SetLoggerFactory(loggerFactory);
                }
                return fenomHubSystemDiscovery;
            }
        }

        public static bool IsAndroid { get => DeviceInfo.Platform == DevicePlatform.Android; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
