using System.Threading.Tasks;

namespace TaxCalculator.Services
{
    public class AlertService : IAlertService
    {
        public async Task ShowAsync(string message)
        {
            await App.Current.MainPage.DisplayAlert("Error", message, "Ok");
        }
    }
}
