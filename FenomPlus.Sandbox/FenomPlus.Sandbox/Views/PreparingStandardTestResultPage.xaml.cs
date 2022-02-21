using System;
using System.Collections.Generic;
using FenomPlus.Sandbox.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Views
{
    public partial class PreparingStandardTestResultPage : ContentPage
    {
        public PreparingStandardTestResultPage()
        {
            InitializeComponent();
            BindingContext = new PreparingStandardTestResultViewModel();
        }
    }
}
