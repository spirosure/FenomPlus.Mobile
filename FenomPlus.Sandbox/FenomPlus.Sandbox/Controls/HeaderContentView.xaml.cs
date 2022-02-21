using System;
using System.Collections.Generic;
using FenomPlus.Sandbox.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Controls
{
    public partial class HeaderContentView : ContentView
    {
        public HeaderContentView()
        {
            InitializeComponent();
            BindingContext = new HeaderContentViewModel();
        }
    }
}
