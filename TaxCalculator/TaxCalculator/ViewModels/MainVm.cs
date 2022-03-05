using System;
using System.Threading.Tasks;
using MvvmHelpers;
using TaxCalculator.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace TaxCalculator.ViewModels
{
    public class MainVm : BaseViewModel
    {
        private string _zip;
        public string Zip
        {
            get => _zip;
            set
            {
                _zip = value;
                OnPropertyChanged();
                GetTaxRateCommand.RaiseCanExecuteChanged();
            }
        }

        public IAsyncCommand GetTaxRateCommand { get; }

        private readonly ITaxService _taxService;

        public MainVm(ITaxService taxService)
        {
            _taxService = taxService;
            GetTaxRateCommand = new AsyncCommand(GetTaxRate, canExecute: (_) => CanGetZipTaxRate(Zip));
        }

        private async Task GetTaxRate()
        {
            var rates = await _taxService.GetRatesForZip(_zip);
        }

        private readonly Func<string, bool> CanGetZipTaxRate = zip =>
            !string.IsNullOrWhiteSpace(zip) && zip.Length == 5;
    }
}
