
using FenomPlus.Enums;

namespace FenomPlus.ViewModels
{
    public class TestErrorViewModel : BaseViewModel
    {
        public TestErrorViewModel()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnAppearing()
        {
            base.OnAppearing();
            UpdateError();
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

        /// <summary>
        /// 
        /// </summary>
        private void UpdateError()
        {
            int statusCode = (Cache._BreathManeuver.StatusCode >= ErrorCodesEnum.codes.Length) ?
                ErrorCodesEnum.codes.Length :
                Cache._BreathManeuver.StatusCode;

            ErrorCode = string.Format("E-{0}", statusCode.ToString("000"));
            ErrorMessage = ErrorCodesEnum.codes[statusCode];
        }

        /// <summary>
        /// 
        /// </summary>
        private string _ErrorMessage;
        public string ErrorMessage
        {
            get => _ErrorMessage;
            set
            {
                _ErrorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _ErrorCode;
        public string ErrorCode
        {
            get => _ErrorCode;
            set
            {
                _ErrorCode = value;
                OnPropertyChanged("ErrorCode");
            }
        }
    }
}
