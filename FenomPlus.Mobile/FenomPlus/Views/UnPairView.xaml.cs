using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class UnPairView : ContentPage
    {
        private UnPairViewModel model;

        public UnPairView()
        {
            InitializeComponent();
            BindingContext = model = new UnPairViewModel();
        }
    }
}
