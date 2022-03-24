using System;
using System.Collections.Generic;
using FenomPlus.Sandbox.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Views
{
    public partial class LiveDataPage : ContentPage
    {
        private LiveDataViewModel model;

        public LiveDataPage()
        {
            InitializeComponent();
            BindingContext = model = new LiveDataViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            App.BleDevice.DisconnectAsync();
            Shell.Current.Navigation.PopToRootAsync();
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
    }
}
