using System;
using System.Collections.Generic;
using FenomPlus.Sandbox.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Views
{
    public partial class GaugePage : ContentPage
    {
        public GaugePage()
        {
            InitializeComponent();
            BindingContext = new GaugeViewModel();
        }
    }
}
