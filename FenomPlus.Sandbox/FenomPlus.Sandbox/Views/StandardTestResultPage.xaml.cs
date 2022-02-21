using System;
using System.Collections.Generic;
using FenomPlus.Sandbox.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Views
{
    public partial class StandardTestResultPage : ContentPage
    {
        public StandardTestResultPage()
        {
            InitializeComponent();
            BindingContext = new StandardTestResultViewModel();
        }
    }
}
