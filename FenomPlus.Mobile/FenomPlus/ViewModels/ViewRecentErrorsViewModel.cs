﻿using System;
using FenomPlus.Helpers;
using FenomPlus.Models;

namespace FenomPlus.ViewModels
{
    public class ViewRecentErrorsViewModel : BaseViewModel
    {
        public ViewRecentErrorsViewModel()
        {
            DataForGrid = new RangeObservableCollection<ViewRecentErrorsDataModel>();
            for (int i = 0; i < 10; i++)
            {
                DataForGrid.Add(new ViewRecentErrorsDataModel() { });
            }
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

        /// <summary>
        /// 
        /// </summary>
        private RangeObservableCollection<ViewRecentErrorsDataModel> _DataForGrid;
        public RangeObservableCollection<ViewRecentErrorsDataModel> DataForGrid
        {
            get => _DataForGrid;
            set
            {
                _DataForGrid = value;
                OnPropertyChanged("DataForGrid");
            }
        }
    }
}
