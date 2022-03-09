
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.ViewModels;
using Xamarin.Forms;

namespace TaxCalculator.Pages
{
    public partial class LocationTaxPage : ContentPage
    {
        public LocationTaxPage()
        {
            InitializeComponent();
            BindingContext = DependencyInjection.ServiceProvider.GetService<LocationTaxVm>();
        }
    }
}
