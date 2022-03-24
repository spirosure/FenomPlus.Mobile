using System;

namespace FenomPlus.Sandbox.ViewModels
{
    public class StandardTestResultViewModel : BaseViewModel
    {
        public StandardTestResultViewModel()
        {
        }

        private bool Stop;

        /// <summary>
        /// 
        /// </summary>
        public void OnAppearing()
        {
            Stop = false;
            TestResult = App.TestResult;
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnDisappearing()
        {
            Stop = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private float testResult;
        public float TestResult
        {
            get => testResult;
            set
            {
                testResult = value;
                OnPropertyChanged("TestResult");
            }
        }
    }
}
