using System;
using System.Collections.Generic;
using FenomPlus.Sandbox.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Views
{
    public partial class MainPage : Shell
    {
        private MainViewModel model;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = model = new MainViewModel();
        }
    }
}
