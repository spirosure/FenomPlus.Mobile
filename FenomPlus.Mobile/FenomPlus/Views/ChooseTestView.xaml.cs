using System;
using System.Collections.Generic;
using FenomPlus.Models;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class ChooseTestView : BaseContentPage
    {
        private ChooseTestViewModel model;

        public ChooseTestView()
        {
            InitializeComponent();
            BindingContext = model = new ChooseTestViewModel();
            //Shell.Current.IsVisible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnStandartTest(object sender, EventArgs e)
        {
            App.TestType = TestTypeEnum.Standard;
            await Shell.Current.GoToAsync(new ShellNavigationState("StartTestView"), false);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnShortTest(object sender, EventArgs e)
        {
            App.TestType = TestTypeEnum.Short;
            await Shell.Current.GoToAsync(new ShellNavigationState("StartTestView"), false);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.OnAppearing();
            if ((App.BleDevice == null) || (App.BleDevice.Connected == false))
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    //await Shell.Current.GoToAsync(new ShellNavigationState("DevicePowerOnView"), false);
                });
            }
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
