using System;

namespace FenomPlus.Sandbox.ViewModels
{
    public class StandardTestViewModel : BaseViewModel
    {
        public StandardTestViewModel()
        {
        }

        private bool Stop;

        public void OnAppearing()
        {
            Stop = false;
        }

        public void OnDisappearing()
        {
            Stop = true;
        }
    }
}
