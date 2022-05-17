using System;
using FenomPlus.Helpers;
using FenomPlus.Models;

namespace FenomPlus.ViewModels
{
    public class QualityControlUsersViewModel : BaseViewModel
    {
        public QualityControlUsersViewModel()
        {
            DataForGrid = new RangeObservableCollection<QualityControlUsersDataModel>();
            for (int i = 0; i < 10; i++)
            {
                DataForGrid.Add(new QualityControlUsersDataModel());
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
        private RangeObservableCollection<QualityControlUsersDataModel> _DataForGrid;
        public RangeObservableCollection<QualityControlUsersDataModel> DataForGrid
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
