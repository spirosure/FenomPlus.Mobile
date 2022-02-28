using Xamarin.Forms;
using FenomPlus.SDK.Core.Ble.Interface;
using FenomPlus.SDK.Abstractions;
using Xamarin.Essentials;
using Microsoft.Extensions.Logging;
using FenomPlus.SDK.Core;
using FenomPlus.Sandbox.Views;
using System.Threading.Tasks;

namespace FenomPlus.Sandbox
{
    public partial class App : Application
    {
        public static int ScanSeconds = 30;
        public static bool ContinueScan = false;
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

            Routing.RegisterRoute("BleDevicePage", typeof(BleDevicePage));
            Routing.RegisterRoute("GaugePage", typeof(GaugePage));
            Routing.RegisterRoute("MainPage", typeof(GaugePage));
            Routing.RegisterRoute("PreparingStandardTestResultPage", typeof(PreparingStandardTestResultPage));
            Routing.RegisterRoute("ScanBlePage", typeof(ScanBlePage));
            Routing.RegisterRoute("StandardTestPage", typeof(StandardTestPage));
            Routing.RegisterRoute("StandardTestResultPage", typeof(StandardTestResultPage));
            Routing.RegisterRoute("StopExhalingPage", typeof(StopExhalingPage));


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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task DisconnectDevice()
        {
            // disconnect device first
            if ((App.BleDevice != null) && (App.BleDevice.Connected))
            {
                await App.BleDevice.DisconnectAsync();
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
