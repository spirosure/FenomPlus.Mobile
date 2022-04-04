using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class ViewRecentErrorsView : BaseContentPage
    {
        private ViewRecentErrorsViewModel model;

        public ViewRecentErrorsView()
        {
            InitializeComponent();
            BindingContext = model = new ViewRecentErrorsViewModel();
        }
    }
}
