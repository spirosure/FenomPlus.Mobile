using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class TestErrorView : BaseContentPage
    {
        private TestErrorViewModel model;

        public TestErrorView()
        {
            InitializeComponent();
            BindingContext = model = new TestErrorViewModel();
        }
    }
}
