using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Controls
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
