using System;
using FenomPlus.Models;
using Xamarin.Forms;

namespace FenomPlus.ViewModels
{
    public class StartTestViewModel : BaseViewModel
    {
        public StartTestViewModel()
        {
        }

        public string TestType
        {
            get { return (App.TestType == TestTypeEnum.Standard) ? "Standard Test" : "Short Test"; }
        }

        public ImageSource TestImageSource
        {
            get { return (App.TestType == TestTypeEnum.Standard) ? "StandardBreathe" : "ShortBreathe"; }
        }

        public string TestSeconds
        {
            get { return (App.TestType == TestTypeEnum.Standard) ? "10 seconds" : "6 seconds"; }
        }
        
        public string TestButton
        {
            get { return (App.TestType == TestTypeEnum.Standard) ? "Take Standard Test" : "Take Short Test"; }
        }
    }
}
