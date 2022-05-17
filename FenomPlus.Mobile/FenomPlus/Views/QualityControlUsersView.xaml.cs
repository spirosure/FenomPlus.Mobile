using System;
using System.Collections.Generic;
using FenomPlus.Helpers;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class QualityControlUsersView : BaseContentPage
    {
        private QualityControlUsersViewModel model;

        public QualityControlUsersView()
        {
            InitializeComponent();
            BindingContext = model = new QualityControlUsersViewModel();
            dataGrid.GridStyle = new CustomGridStyle();
        }
    }
}
