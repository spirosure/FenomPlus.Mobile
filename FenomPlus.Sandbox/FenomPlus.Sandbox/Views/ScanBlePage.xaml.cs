using Xamarin.Forms;
using FenomPlus.Sandbox.ViewModels;

namespace FenomPlus.Sandbox.Views
{
    public partial class ScanBlePage : ContentPage
    {
        private ScanBleViewModel model;

        public ScanBlePage()
        {
            InitializeComponent();

            BindingContext = model = new ScanBleViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.OnAppearing();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            model.OnDisappearing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async() =>
            {
                await App.DisconnectDevice();
                App.BleDevice = ((DeviceFound)e.Item).Device;
                ((ListView)sender).SelectedItem = null;
                if (await App.BleDevice.ConnectAsync())
                {
                    model.StopScan();
                    await Shell.Current.GoToAsync(nameof(StandardTestPage));
                }
            });
        }
    }
}