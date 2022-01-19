using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FenomPlus.Sandbox.ViewModels;
using FenomPlus.SDK.Core.Ble.Interface;

namespace FenomPlus.Sandbox.Views
{
    public partial class AboutPage : ContentPage
    {
        AboutViewModel _viewModel;

        public AboutPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new AboutViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            App.BleDevice = ((DeviceFound)e.Item).Device;
            //await Shell.Current.GoToAsync(nameof(BleDevicePage));
            ((ListView)sender).SelectedItem = null;
        }
    }
}