using System;
using FenomPlus.Models;

namespace FenomPlus.ViewModels
{
    public class ChooseTestViewModel : BaseViewModel
    {
        public ChooseTestViewModel()
        {
            DeviceStatus = new DeviceStatus();
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


        public DeviceStatus DeviceStatus { get;set; }
    }
}
