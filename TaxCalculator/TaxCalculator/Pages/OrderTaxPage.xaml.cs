
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.ViewModels;
using Xamarin.Forms;

namespace TaxCalculator.Pages
{
    public partial class OrderTaxPage : ContentPage
    {
        public OrderTaxPage()
        {
            InitializeComponent();
            BindingContext = DependencyInjection.ServiceProvider.GetService<OrderTaxVm>();
        }
    }
}
