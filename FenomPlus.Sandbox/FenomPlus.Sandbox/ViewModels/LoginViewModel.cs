using FenomPlus.Sandbox.Views;
using Xamarin.Forms;

namespace FenomPlus.Sandbox.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
        }
    }
}
