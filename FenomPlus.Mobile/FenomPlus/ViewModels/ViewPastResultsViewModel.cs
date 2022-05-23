using System;
using FenomPlus.Helpers;
using FenomPlus.Models;

namespace FenomPlus.ViewModels
{
    public class ViewPastResultsViewModel : BaseViewModel
    {
        public ViewPastResultsViewModel()
        {
            DataForGrid = new RangeObservableCollection<ViewPastResultsDataModel>();
            for (int i = 0; i < 10; i++)
            {
                DataForGrid.Add(new ViewPastResultsDataModel() { });
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
        private RangeObservableCollection<ViewPastResultsDataModel> _DataForGrid;
        public RangeObservableCollection<ViewPastResultsDataModel> DataForGrid
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
