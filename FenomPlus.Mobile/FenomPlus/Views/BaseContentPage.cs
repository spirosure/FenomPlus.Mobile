﻿using System;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Interfaces;
using FenomPlus.SDK.Abstractions;
using FenomPlus.SDK.Core.Ble.Interface;
using FenomPlus.Services;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public class BaseContentPage : ContentPage, IBaseServices
    {
        public IBleDevice BleDevice => App.BleDevice;
        public IAppServices Services => IOC.Services;
        public IFenomHubSystemDiscovery FenomHub => App.FenomHubSystemDiscovery;

        // repos here
        public IBreathManeuverErrorRepository ErrorsRepo => Services.Database.BreathManeuverErrorRepo;
        public IBreathManeuverResultRepository ResultsRepo => Services.Database.BreathManeuverResultRepo;
        public IQualityControlRepository QCRepo => Services.Database.QualityControlRepo;
        public IQualityControlDevicesRepository QCDevicesRepo => Services.Database.QualityControlDevicesRepo;
        public IQualityControlUsersRepository QCUsersRepo => Services.Database.QualityControlUsersRepo;


        //protected T model;

        /// <summary>
        /// 
        /// </summary>
        public BaseContentPage()
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
