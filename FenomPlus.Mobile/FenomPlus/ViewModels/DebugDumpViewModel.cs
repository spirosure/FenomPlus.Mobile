using System;
using FenomPlus.Helpers;
using FenomPlus.Models;
using FenomPlus.SDK.Core.Features;

namespace FenomPlus.ViewModels
{
    public class DebugDumpViewModel : BaseViewModel
    {
        public RangeObservableCollection<DebugLog> DebugList => Services.Cache.DebugList;
        public RangeObservableCollection<string> MessageIdList = new RangeObservableCollection<string>();
        public RangeObservableCollection<string> SubIdList = new RangeObservableCollection<string>();

        public DebugDumpViewModel()
        {
            MessageIdList.AddRange(Enum.GetNames(typeof(ID_MESSAGE)));
            SubIdList.AddRange(Enum.GetNames(typeof(ID_SUB)));
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
        override public void NewGlobalData()
        {
            base.NewGlobalData();
        }
    }
}


