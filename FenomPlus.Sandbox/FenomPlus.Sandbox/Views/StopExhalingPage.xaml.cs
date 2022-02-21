using System;
using System.Collections.Generic;
using FenomPlus.Sandbox.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Views
{
    public partial class StopExhalingPage : ContentPage
    {
        public StopExhalingPage()
        {
            InitializeComponent();
            BindingContext = new StopExhalingViewModel();
        }
    }
}
