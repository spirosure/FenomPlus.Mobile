using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class StartScreenView : ContentPage
    {
        private StartScreenViewModel model;

        public StartScreenView()
        {
            InitializeComponent();
            BindingContext = model = new StartScreenViewModel();
        }
    }
}
