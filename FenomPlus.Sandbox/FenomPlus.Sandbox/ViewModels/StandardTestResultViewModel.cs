using System;

namespace FenomPlus.Sandbox.ViewModels
{
    public class StandardTestResultViewModel : BaseViewModel
    {
        public StandardTestResultViewModel()
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
