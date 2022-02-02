using System;
using System.Collections.Generic;
using FenomPlus.Sandbox.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Views
{
    public partial class BleDevicePage : ContentPage
    {
        public BleDevicePage()
        {
            InitializeComponent();
            BindingContext = new BleDeviceViewModel();
        }
    }
}
