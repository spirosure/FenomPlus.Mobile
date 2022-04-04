using System;
using FenomPlus.Models;

namespace FenomPlus.ViewModels
{
    public class TestResultsViewModel : BaseViewModel
    {
        public TestResultsViewModel()
        {
        }

        private bool Stop;

        /// <summary>
        /// 
        /// </summary>
        override public void OnAppearing()
        {
            base.OnAppearing();
            TestResult = App.TestResult;
            Stop = false;
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnDisappearing()
        {
            base.OnDisappearing();
            Stop = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public string TestType
        {
            get { return (App.TestType == TestTypeEnum.Standard) ? "Standard" : "Short" ; }
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
