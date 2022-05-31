using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class NegativeControlFailView : BaseContentPage
    {
        private NegativeControlFailViewModel model;

        public NegativeControlFailView()
        {
            InitializeComponent();
            BindingContext = model = new NegativeControlFailViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnClose(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(QualityControlView)}"), false);
        }
    }
}
