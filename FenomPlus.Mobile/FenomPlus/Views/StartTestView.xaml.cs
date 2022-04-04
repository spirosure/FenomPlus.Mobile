using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class StartTestView : BaseContentPage
    {
        private StartTestViewModel model;

        public StartTestView()
        {
            InitializeComponent();
            BindingContext = model = new StartTestViewModel();
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GoToTutorial(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new TutorialView(), false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnCancel(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(new ShellNavigationState(".."), false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void StartTest(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new BreathManeuverFeedbackView(), false);
            //await Shell.Current.GoToAsync(new ShellNavigationState("BreathManeuverFeedbackView"), false);
        }
    }
}