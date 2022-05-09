using System;
using System.Collections.Generic;
using FenomPlus.Models;

namespace FenomPlus.ViewModels
{
    public class ChooseTestViewModel : BaseViewModel
    {
        public ChooseTestViewModel()
        {
            DeviceStatus = new DeviceStatus();
            ErrorList = new List<Alert>();
            ErrorList.Add(new Alert()
            {
                Description = "F150 has 6% charge with 2 tests remaining. Please connect your device to the charging port.",
                Image = "BatteryWarning",
                Title = "Device Battery Low"
            });
            ErrorList.Add(new Alert()
            {
                Description = "F150 sensor will expire in 60 days. For information on ordering a replacement sensor and how to replace your sensor, please view online FAQ.",
                Image = "SensorWarning",
                Title = "Device Sensor Expiring Soon"
            });
            ErrorList.Add(new Alert()
            {
                Description = "F150 Device will expire in 60 days. For information on ordering a replacement device, please view online FAQ.",
                Image = "DeviceWarning",
                Title = "Device Expiring Soon"
            });
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnAppearing()
        {
            base.OnAppearing();
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnDisappearing()
        {
            base.OnDisappearing();
        }


        public DeviceStatus DeviceStatus { get; set; }

        public List<Alert> ErrorList { get;set; }
    }
}
