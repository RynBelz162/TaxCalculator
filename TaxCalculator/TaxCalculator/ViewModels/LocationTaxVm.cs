﻿using System;
using System.Threading.Tasks;
using MvvmHelpers;
using TaxCalculator.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace TaxCalculator.ViewModels
{
    public class LocationTaxVm : BaseViewModel
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

        private string _rate;
        public string Rate
        {
            get => _rate;
            set
            {
                _rate = value;
                OnPropertyChanged();
            }
        }

        private string _city;
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }

        public IAsyncCommand GetTaxRateCommand { get; }

        private readonly ITaxService _taxService;
        private readonly IAlertService _alertService;

        public LocationTaxVm(ITaxService taxService, IAlertService alertService)
        {
            _taxService = taxService;
            _alertService = alertService;

            GetTaxRateCommand = new AsyncCommand(GetTaxRate, canExecute: () => CanGetZipTaxRate());

            // Set default values to show
            City = "Unknown";
            Rate = "Unknown";
        }

        public async Task GetTaxRate()
        {
            IsBusy = true;

            try
            {
                var (city, rate) = await _taxService.GetRateForZip(_zip)
                    .ConfigureAwait(false);


                City = string.IsNullOrWhiteSpace(city) ? "Unknown" : city;

                Rate = $"{rate * 100} %";
            }
            catch
            {
                await _alertService.ShowAsync("Something has gone wrong finding your tax location :(");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public bool CanGetZipTaxRate() =>
            !string.IsNullOrWhiteSpace(Zip) && Zip.Length == 5;
    }
}
