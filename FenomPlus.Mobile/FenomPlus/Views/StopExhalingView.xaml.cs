using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class StopExhalingView : BaseContentPage
    {
        private StopExhalingViewModel model;

        public StopExhalingView()
        {
            InitializeComponent();
            BindingContext = model = new StopExhalingViewModel();
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

        /// <summary>
        /// 
        /// </summary>
        protected override void NewGlobalData()
        {
            base.NewGlobalData();
            model.NewGlobalData();
        }
    }
}
