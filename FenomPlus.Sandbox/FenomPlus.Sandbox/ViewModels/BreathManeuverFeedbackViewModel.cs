using System;

using Xamarin.Forms;

namespace FenomPlus.Sandbox.ViewModels
{
    public class BreathManeuverFeedbackViewModel : BaseViewModel
    {
        public BreathManeuverFeedbackViewModel()
        {
            GuageData = 3.4f;
            GuageText = "Seconds";
            GuageValue = "9.0";
            SliderValue = 3;
        }


        private float guageData;
        public float GuageData
        {
            get => guageData;
            set
            {
                guageData = value;
                OnPropertyChanged("GuageData");
            }
        }


        private string guageValue;
        public string GuageValue
        {
            get => guageValue;
            set
            {
                guageValue = value;
                OnPropertyChanged("GuageValue");
            }
        }


        private string guageText;
        public string GuageText
        {
            get => guageText;
            set
            {
                guageText = value;
                OnPropertyChanged("GuageText");
            }
        }

        private double sliderValue;
        public double SliderValue
        {
            get => sliderValue;
            set
            {
                sliderValue = value;
                GuageData = (float)value;
                GuageValue = value.ToString();
                OnPropertyChanged("SliderValue");
            }
        }
        
    }
}

