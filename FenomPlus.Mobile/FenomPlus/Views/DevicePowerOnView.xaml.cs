using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class DevicePowerOnView : ContentPage
    {
        private DevicePowerOnViewModel model;

        public DevicePowerOnView()
        {
            InitializeComponent();

            BindingContext = model = new DevicePowerOnViewModel();
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
