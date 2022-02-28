using FenomPlus.Sandbox.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Views
{
    public partial class StandardTestResultPage : ContentPage
    {
        private StandardTestResultViewModel model;

        public StandardTestResultPage()
        {
            InitializeComponent();
            BindingContext = model = new StandardTestResultViewModel();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Finish_Pressed(System.Object sender, System.EventArgs e)
        {
            Shell.Current.Navigation.PopToRootAsync();
        }
    }
}
