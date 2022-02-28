using FenomPlus.Sandbox.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Views
{
    public partial class StandardTestPage : ContentPage
    {
        private StandardTestViewModel model;

        public StandardTestPage()
        {
            InitializeComponent();
            BindingContext = model = new StandardTestViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Tutorial_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.Navigation.PopToRootAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.Navigation.PopToRootAsync();
        }

        /// <summary>
        /// s
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TakeStandardTest_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(GaugePage));
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
