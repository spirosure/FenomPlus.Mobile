using FenomPlus.Sandbox.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}