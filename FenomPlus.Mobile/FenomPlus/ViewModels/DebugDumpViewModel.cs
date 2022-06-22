using FenomPlus.Helpers;

namespace FenomPlus.ViewModels
{
    public class DebugDumpViewModel : BaseViewModel
    {
        public RangeObservableCollection<string> DebugList => Services.Cache.DebugList;

        public DebugDumpViewModel()
        {
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


