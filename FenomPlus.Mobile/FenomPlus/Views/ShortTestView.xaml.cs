using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class ShortTestView : ContentPage
    {
        public ShortTestView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GoToTutorial(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(new ShellNavigationState("TutorialView"), false);
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
        private void StartShortTest(object sender, EventArgs e)
        {
            // start test here
        }
    }
}
