using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class HumanControlPreparingView : BaseContentPage
    {
        private HumanControlPreparingViewModel model;

        public HumanControlPreparingView()
        {
            InitializeComponent();
            BindingContext = model = new HumanControlPreparingViewModel();
        }
    }
}
