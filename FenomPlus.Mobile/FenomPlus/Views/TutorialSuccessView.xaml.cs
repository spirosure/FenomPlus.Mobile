using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class TutorialSuccessView : BaseContentPage
    {
        private TutorialSuccessViewModel model;

        public TutorialSuccessView()
        {
            InitializeComponent();
            BindingContext = model = new TutorialSuccessViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnFinish(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync(new ShellNavigationState("///ChooseTestView"), false);
 //           await Shell.Current.GoToAsync(new ShellNavigationState(".."), false);
        }
    }
}
