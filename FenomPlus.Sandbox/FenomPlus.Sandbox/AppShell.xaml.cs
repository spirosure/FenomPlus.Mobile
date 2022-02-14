﻿using FenomPlus.Sandbox.ViewModels;
using FenomPlus.Sandbox.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FenomPlus.Sandbox
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BleDevicePage), typeof(BleDevicePage));
            Routing.RegisterRoute(nameof(BreathManeuverFeedbackPage), typeof(BreathManeuverFeedbackPage));
            
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
