using Xamarin.Forms;
using FenomPlus.SDK.Core.Ble.Interface;
using FenomPlus.SDK.Abstractions;
using Xamarin.Essentials;
using Microsoft.Extensions.Logging;
using FenomPlus.SDK.Core;
using FenomPlus.Views;
using System.Threading.Tasks;
using FenomPlus.Models;

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

        public App()
        {
            InitializeComponent();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQwNDYxQDMyMzAyZTMxMmUzMGlPTklYM3hoQmpKc2F2bVlEUFBBS29YU1FGQTBWSTZyY2RJbkJBVm1pbEU9");

            App.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Debug)
                    .AddFilter("FenomPlus", LogLevel.Debug);
            });

            /*
            Routing.RegisterRoute("AnalysisView", typeof(AnalysisView));
            Routing.RegisterRoute("BleDevicePairingView", typeof(BleDevicePairingView));
            Routing.RegisterRoute("BreathManeuverFeedbackView", typeof(BreathManeuverFeedbackView));            
            Routing.RegisterRoute("ChooseTestView", typeof(ChooseTestView));
            Routing.RegisterRoute("DevicePowerOnView", typeof(DevicePowerOnView));
            Routing.RegisterRoute("DeviceReadyView", typeof(DeviceReadyView));            
            Routing.RegisterRoute("EndOfBreathManeuverFeedbackView", typeof(EndOfBreathManeuverFeedbackView));
            Routing.RegisterRoute("FirmwareUpdateView", typeof(FirmwareUpdateView));
            Routing.RegisterRoute("InstructionsView", typeof(InstructionsView));
            Routing.RegisterRoute("MainView", typeof(MainView));
            Routing.RegisterRoute("PreparingStandardTestResultView", typeof(PreparingStandardTestResultView));
            Routing.RegisterRoute("QualityControlView", typeof(QualityControlView));
            Routing.RegisterRoute("QualityControlUsersView", typeof(QualityControlUsersView));
            Routing.RegisterRoute("QualityControlDevicesView", typeof(QualityControlDevicesView));
            Routing.RegisterRoute("SettingsView", typeof(SettingsView));
            Routing.RegisterRoute("StartScreenView", typeof(StartScreenView));
            Routing.RegisterRoute("StartTestView", typeof(StartTestView));
            Routing.RegisterRoute("StopExhalingView", typeof(StopExhalingView));
            Routing.RegisterRoute("TestErrorView", typeof(TestErrorView));
            Routing.RegisterRoute("TestFailedView", typeof(TestFailedView));            
            Routing.RegisterRoute("TestResultsView", typeof(TestResultsView));
            Routing.RegisterRoute("TutorialView", typeof(TutorialView));
            Routing.RegisterRoute("TutorialSuccessView", typeof(TutorialSuccessView));            
            Routing.RegisterRoute("UnPairView", typeof(UnPairView));
            Routing.RegisterRoute("ViewPastResultsView", typeof(ViewPastResultsView));
            Routing.RegisterRoute("ViewRecentErrorsView", typeof(ViewRecentErrorsView));
            */
            MainPage = new MainView();
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
