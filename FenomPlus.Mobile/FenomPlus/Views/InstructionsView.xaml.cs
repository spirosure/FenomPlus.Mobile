using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class InstructionsView : BaseContentPage
    {
        private InstructionsViewModel model;

        public InstructionsView()
        {
            InitializeComponent();
            BindingContext = model = new InstructionsViewModel();
        }
    }
}
