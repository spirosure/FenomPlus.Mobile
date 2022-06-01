using Xamarin.Forms;
using FenomPlus.SDK.Core.Ble.Interface;
using FenomPlus.SDK.Abstractions;
using Xamarin.Essentials;
using Microsoft.Extensions.Logging;
using FenomPlus.SDK.Core;
using FenomPlus.Views;
using System.Threading.Tasks;
using FenomPlus.Models;
using System.Text;

namespace FenomPlus
{
    public partial class App : Application
    {
        public static float TestResult { get; set; }
        public static int ScanSeconds = 25;
        public static int ReadBreathData = 200;
        public static bool ContinueScan = false;
        public static TestTypeEnum TestType = TestTypeEnum.Standard;
        public static ILoggerFactory loggerFactory { get; set; }
        public static IBleDevice BleDevice { get; set; }
        public static bool DeviceNewVersion { get; set; }
        public static byte BatteryLevel { get; set; }
        public static string DeviceSerialNumber;

        public App()
        {
            // force to true for now
            DeviceNewVersion = true;
            DeviceSerialNumber = "F150-1234567";

            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQwNDYxQDMyMzAyZTMxMmUzMGlPTklYM3hoQmpKc2F2bVlEUFBBS29YU1FGQTBWSTZyY2RJbkJBVm1pbEU9");

            App.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Debug)
                    .AddFilter("FenomPlus", LogLevel.Debug);
            });

            MainPage = new MainView();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialNumber"></param>
        public static string SetDeviceSerialNumber(byte[] serialNumber)
        {
            if ((serialNumber != null) && (serialNumber.Length > 0))
            {
                DeviceSerialNumber = Encoding.Default.GetString(serialNumber);
            }
            return DeviceSerialNumber;
        }

        private static IFenomHubSystemDiscovery fenomHubSystemDiscovery;
        public static IFenomHubSystemDiscovery FenomHubSystemDiscovery
        {
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
