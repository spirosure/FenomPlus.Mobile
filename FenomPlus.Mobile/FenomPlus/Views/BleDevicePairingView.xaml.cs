﻿using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class BleDevicePairingView : BaseContentPage<BleDevicePairingViewModel>
    {        
        public BleDevicePairingView()
        {
            InitializeComponent();
            BindingContext = model = new BleDevicePairingViewModel();
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
