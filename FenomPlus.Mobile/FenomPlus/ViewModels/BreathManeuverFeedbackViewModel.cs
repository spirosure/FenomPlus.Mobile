using System;
using FenomPlus.Helpers;
using FenomPlus.Models;
using FenomPlus.Views;
using Xamarin.Forms;

namespace FenomPlus.ViewModels
{
    public class BreathManeuverFeedbackViewModel : BaseViewModel
    {
        private bool StartMeasure;

        public BreathManeuverFeedbackViewModel()
        {
        }

        private bool Stop;

        private string _TestType;
        public string TestType
        {
            get => _TestType;
            set
            {
                _TestType = value;
                OnPropertyChanged("TestType");
            }
        }

        private int _TestTime;
        public int TestTime
        {
            get => _TestTime;
            set
            {
                _TestTime = value;
                OnPropertyChanged("TestTime");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnAppearing()
        {
            base.OnAppearing();
            if (Cache.TestType == TestTypeEnum.Standard)
            {
                TestType = "Standard Test";
                TestTime = 10;
            }
            else
            {
                TestType = "Short Test";
                TestTime = 6;
            }

            Stop = false;
            StartMeasure = false;

            TestSeconds = TestTime * (1000 / Cache.ReadBreathData);
            GuageData = 0;
            GuageSeconds = TestTime * (1000 / Cache.ReadBreathData);
            GuageStatus = "Start Blowing";

            // start timer
            Device.StartTimer(TimeSpan.FromMilliseconds(Cache.ReadBreathData), () =>
            {
                // have we started the Measure yet?
                if (StartMeasure == true)
                {
                    TestSeconds--;
                    if ((TestSeconds <= 0) && (Stop == false))
                    {
                        BleHub.StopTest();
                        Shell.Current.GoToAsync(new ShellNavigationState($"///{nameof(StopExhalingView)}"), false);
                    }
                }

                if (Cache._BreathManeuver != null)
                {
                    GuageData = (float)(((float)Cache._BreathManeuver.BreathFlow) / 10);

                    if ((GuageData <= 0.0f) && (StartMeasure == false))
                    {
                        GuageStatus = "Start Blowing";
                    }
                    else
                    {
                        StartMeasure = true;
                        if (GuageData < 2.8f)
                        {
                            GuageStatus = "Exhale Harder";
                        }
                        else if (GuageData > 3.2f)
                        {
                            GuageStatus = "Exhale Softer";
                        }
                        else
                        {
                            GuageStatus = "Good Job!";
                        }
                    }
                }

                // return contiune of below the time
                GuageSeconds = TestSeconds / (1000 / Cache.ReadBreathData);
                return (TestSeconds > 0) && (Stop == false);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnDisappearing()
        {
            base.OnDisappearing();
            Stop = true;
            PlaySounds.StopAll();
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartBleNotify()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void StopBleNotify()
        {

        }

        private int TestSeconds;

        /// <summary>
        /// 
        /// </summary>
        private int guageSeconds;
        public int GuageSeconds
        {
            get => guageSeconds;
            set
            {
                guageSeconds = value;
                OnPropertyChanged("GuageSeconds");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private float guageData;
        public float GuageData
        {
            get => guageData;
            set
            {
                guageData = value;
                OnPropertyChanged("GuageData");
                if(!Stop) PlaySounds.PlaySound(GuageData);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string guageStatus;
        public string GuageStatus
        {
            get => guageStatus;
            set
            {
                guageStatus = value;
                OnPropertyChanged("GuageStatus");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        override public void NewGlobalData()
        {
            base.NewGlobalData();
        }
    }
}
