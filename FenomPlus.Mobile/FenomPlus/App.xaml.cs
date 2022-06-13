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
using FenomPlus.Services;

namespace FenomPlus
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQwNDYxQDMyMzAyZTMxMmUzMGlPTklYM3hoQmpKc2F2bVlEUFBBS29YU1FGQTBWSTZyY2RJbkJBVm1pbEU9");

            MainPage = new MainView();
        }

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
