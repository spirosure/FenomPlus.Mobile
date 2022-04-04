using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class FirmwareUpdateView : BaseContentPage
    {
        private FirmwareUpdateViewModel model;

        public FirmwareUpdateView()
        {
            InitializeComponent();
            BindingContext = model = new FirmwareUpdateViewModel();
        }
    }
}
