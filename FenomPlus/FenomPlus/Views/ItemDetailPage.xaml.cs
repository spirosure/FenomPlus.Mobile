using FenomPlus.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FenomPlus.Views
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