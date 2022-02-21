using System;

using Xamarin.Forms;

namespace FenomPlus.Sandbox.ViewModels
{
    public class PreparingStandardTestResultViewModel : ContentPage
    {
        public PreparingStandardTestResultViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

