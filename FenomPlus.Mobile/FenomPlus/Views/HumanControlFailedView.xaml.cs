﻿using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class HumanControlFailedView : BaseContentPage
    {
        private HumanControlFailedViewModel model;

        public HumanControlFailedView()
        {
            InitializeComponent();
            BindingContext = model = new HumanControlFailedViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Finish_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(QualityControlView)}"), false);
        }
    }
}
