using System;
using System.Threading.Tasks;
using MvvmHelpers;
using TaxCalculator.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace TaxCalculator.ViewModels
{
    public class OrderTaxVm : BaseViewModel
    {
        private string _toZip;
        public string ToZip
        {
            get => _toZip;
            set
            {
                _toZip = value;
                OnPropertyChanged();
                CalculateOrderTax.RaiseCanExecuteChanged();
            }
        }

        private string _toState;
        public string ToState
        {
            get => _toState;
            set
            {
                _toState = value;
                OnPropertyChanged();
                CalculateOrderTax.RaiseCanExecuteChanged();
            }
        }

        private string _fromZip;
        public string FromZip
        {
            get => _fromZip;
            set
            {
                _fromZip = value;
                OnPropertyChanged();
                CalculateOrderTax.RaiseCanExecuteChanged();
            }
        }

        private string _fromState;
        public string FromState
        {
            get => _fromState;
            set
            {
                _fromState = value;
                OnPropertyChanged();
                CalculateOrderTax.RaiseCanExecuteChanged();
            }
        }

        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged();
                CalculateOrderTax.RaiseCanExecuteChanged();
            }
        }

        private decimal _shipping;
        public decimal Shipping
        {
            get => _shipping;
            set
            {
                _shipping = value;
                OnPropertyChanged();
                CalculateOrderTax.RaiseCanExecuteChanged();
            }
        }

        private bool _isValidAmount;
        public bool IsValidAmount
        {
            get => _isValidAmount;
            set
            {
                _isValidAmount = value;
                OnPropertyChanged();
                CalculateOrderTax.RaiseCanExecuteChanged();
            }
        }

        private bool _isValidShipping;
        public bool IsValidShipping
        {
            get => _isValidShipping;
            set
            {
                _isValidShipping = value;
                OnPropertyChanged();
                CalculateOrderTax.RaiseCanExecuteChanged();
            }
        }

        private string _amountToCollect;
        public string AmountToCollect
        {
            get => _amountToCollect;
            set
            {
                _amountToCollect = value;
                OnPropertyChanged();
            }
        }

        public IAsyncCommand CalculateOrderTax { get; }

        private readonly ITaxService _taxService;
        private readonly IAlertService _alertService;

        public OrderTaxVm(ITaxService taxService, IAlertService alertService)
        {
            _taxService = taxService;
            _alertService = alertService;

            CalculateOrderTax = new AsyncCommand(CalculateTax, () => CanCalculate());

            AmountToCollect = "$0";
        }

        public async Task CalculateTax()
        {
            IsBusy = true;

            try
            {
                var amount = await _taxService
                    .CalculateTaxForOrder(toState: ToState, toZip: ToZip, fromState: FromState, fromZip: FromZip, shipping: Shipping, amount: Amount)
                    .ConfigureAwait(false);

                AmountToCollect = $"${amount}";
            }
            catch
            {
                await _alertService.ShowAsync("Something has gone wrong calculating the tax :(");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public bool CanCalculate() =>
            _isValidAmount
            && _isValidShipping
            && !string.IsNullOrWhiteSpace(ToZip) && ToZip.Length == 5
            && !string.IsNullOrWhiteSpace(FromZip) && FromZip.Length == 5
            && !string.IsNullOrWhiteSpace(ToState)
            && !string.IsNullOrWhiteSpace(FromState);
    }
}
