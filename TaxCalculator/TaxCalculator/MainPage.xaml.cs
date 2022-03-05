using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.ViewModels;
using Xamarin.Forms;

namespace TaxCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = DependencyInjection.ServiceProvider.GetService<MainVm>();
        }
    }
}

