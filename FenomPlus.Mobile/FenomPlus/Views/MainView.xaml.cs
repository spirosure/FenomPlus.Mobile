using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class MainView : Shell
    {
        private MainViewModel model;

        public MainView()
        {
            InitializeComponent();
            BindingContext = model = new MainViewModel();
        }
    }
}
