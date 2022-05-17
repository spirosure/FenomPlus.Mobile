using System;
using FenomPlus.Helpers;
using FenomPlus.Models;

namespace FenomPlus.ViewModels
{
    public class QualityControlDevicesViewModel : BaseViewModel
    {
        public QualityControlDevicesViewModel()
        {
            DataForGrid = new RangeObservableCollection<QualityControlDevicesDataModel>();
            for (int i = 0; i < 10; i++)
            {
                DataForGrid.Add(new QualityControlDevicesDataModel());
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
        private RangeObservableCollection<QualityControlDevicesDataModel> _DataForGrid;
        public RangeObservableCollection<QualityControlDevicesDataModel> DataForGrid
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
