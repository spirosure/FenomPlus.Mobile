using System;
using System.Collections.Generic;
using System.Threading;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class DebugDumpView : BaseContentPage
    {
        private DebugDumpViewModel model;

        public DebugDumpView()
        {
            InitializeComponent();
            BindingContext = model = new DebugDumpViewModel();
            DebugListView.ItemsSource = model.DebugList;
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
