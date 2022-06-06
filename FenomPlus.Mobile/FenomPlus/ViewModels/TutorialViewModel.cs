using System;
using FenomPlus.Helpers;
using Xamarin.Forms;

namespace FenomPlus.ViewModels
{
    public class TutorialViewModel : BaseViewModel
    {
        public TutorialViewModel()
        {
        }

        private bool Stop;

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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
        override public void OnAppearing()
        {
            base.OnAppearing();
            Stop = false;

            // start timer to read measure constally
            Device.StartTimer(TimeSpan.FromMilliseconds(App.ReadBreathData), () =>
            {
                Device.BeginInvokeOnMainThread(async () => {
                    // TODO: read from ble charestic
                    if ((Stop == false) && (App.BleDevice != null) && (App.BleDevice.Connected))
                    {
                        var breathManeuver = await App.BleDevice.ReadBreathManeuverFeature();
                        if (breathManeuver != null)
                        {
                            GuageData = (float)(((float)breathManeuver.BreathFlow) / 10);
                        }
                    }
                });
                return !Stop;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnDisappearing()
        {
            base.OnDisappearing();
            Stop = true;
            PlaySounds.StopAll();
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
                if ((!Stop) && (Postion == 5 || Postion == 6 || Postion == 7))
                {
                    PlaySounds.PlaySound(GuageData);
                } else
                {
                    PlaySounds.StopAll();
                }
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

        protected int postion;
        public int Postion
        {
            get => postion;
            set
            {
                postion = value;
                OnPropertyChanged("Postion");
            }
        }
    }
}
