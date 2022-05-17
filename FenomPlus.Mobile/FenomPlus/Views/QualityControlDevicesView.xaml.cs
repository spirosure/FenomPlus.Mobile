using System;
using System.Collections.Generic;
using FenomPlus.Helpers;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class QualityControlDevicesView : BaseContentPage
    {
        private QualityControlDevicesViewModel model;

        public QualityControlDevicesView()
        {
            InitializeComponent();
            BindingContext = model = new QualityControlDevicesViewModel();
            dataGrid.GridStyle = new CustomGridStyle();
        }
    }
}
