using System;
using FenomPlus.Helpers;
using FenomPlus.Models;

namespace FenomPlus.ViewModels
{
    public class QualityControlViewModel : BaseViewModel
    {
        public QualityControlViewModel()
        {
            DataForGrid = new RangeObservableCollection<QualityControlDataModel>();
            for (int i = 0; i < 5; i++)
            {
                DataForGrid.Add(new QualityControlDataModel() { SerialNumber = "F150-23de121w1", TestResults = i.ToString() });
            }
            for (int i = 0; i < 1; i++)
            {
                DataForGrid.Add(new QualityControlDataModel() { SerialNumber = "F150-23de121w2", TestResults = i.ToString() });
            }
            for (int i = 0; i < 10; i++)
            {
                DataForGrid.Add(new QualityControlDataModel() { SerialNumber = "F150-23de121w3", TestResults = i.ToString() });
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
        private RangeObservableCollection<QualityControlDataModel> _DataForGrid;
        public RangeObservableCollection<QualityControlDataModel> DataForGrid
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
