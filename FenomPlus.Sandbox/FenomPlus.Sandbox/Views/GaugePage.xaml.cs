using FenomPlus.Sandbox.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Views
{
    public partial class GaugePage : ContentPage
    {
        private GaugeViewModel model;

        public GaugePage()
        {
            InitializeComponent();
            BindingContext = model = new GaugeViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.Navigation.PopToRootAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.OnAppearing();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            model.OnDisappearing();
        }
    }
}
