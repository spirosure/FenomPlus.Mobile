using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class PreparingStandardTestResultView : ContentPage
    {
        private PreparingStandardTestResultViewModel model;

        public PreparingStandardTestResultView()
        {
            InitializeComponent();
            BindingContext = model = new PreparingStandardTestResultViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.OnAppearing();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            model.OnDisappearing();
        }
    }
}
