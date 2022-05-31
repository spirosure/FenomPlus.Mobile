using System;
using System.Collections.Generic;
using FenomPlus.Database.Adapters;
using FenomPlus.Database.Tables;
using FenomPlus.Helpers;
using FenomPlus.Models;

namespace FenomPlus.ViewModels
{
    public class ViewPastResultsViewModel : BaseViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ViewPastResultsViewModel()
        {
            DataForGrid = new RangeObservableCollection<BreathManeuverResultDataModel>();
            UpdateGrid();
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateGrid()
        {
            DataForGrid.Clear();
            IEnumerable<BreathManeuverResultTb> records = ResultsRepo.SelectAll();
            foreach (BreathManeuverResultTb record in records)
            {
                AddToGrid(record);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        public void AddToGrid(BreathManeuverResultTb record)
        {
            if (record != null)
            {
                DataForGrid.Add(record.ConvertForGrid());
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
        private RangeObservableCollection<BreathManeuverResultDataModel> _DataForGrid;
        public RangeObservableCollection<BreathManeuverResultDataModel> DataForGrid
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
