using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class SettingsView : BaseContentPage
    {
        private SettingsViewModel model;

        public SettingsView()
        {
            InitializeComponent();
            BindingContext = model = new SettingsViewModel();
        }
    }
}
