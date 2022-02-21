using FenomPlus.Sandbox.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Views
{
    public partial class StandardTestPage : ContentPage
    {
        public StandardTestPage()
        {
            InitializeComponent();
            BindingContext = new StandardTestViewModel();
        }
    }
}
