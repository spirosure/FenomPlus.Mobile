﻿using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class HumanControlPassedView : BaseContentPage
    {
        private HumanControlPassedViewModel model;

        public HumanControlPassedView()
        {
            InitializeComponent();
            BindingContext = model = new HumanControlPassedViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnFinish(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(QualityControlView)}"), false);
        }
    }
}