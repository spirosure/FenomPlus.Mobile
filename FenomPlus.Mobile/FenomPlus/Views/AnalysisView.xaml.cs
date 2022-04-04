using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class AnalysisView : ContentPage
    {
        private AnalysisViewModel model;

        public AnalysisView()
        {
            InitializeComponent();
            BindingContext = model = new AnalysisViewModel();
        }
    }
}
