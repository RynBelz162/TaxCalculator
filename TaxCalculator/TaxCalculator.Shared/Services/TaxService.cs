using System.Threading.Tasks;
using TaxCalculator.Shared.Http;
using TaxCalculator.Shared.Models.TaxJar;

namespace TaxCalculator.Shared.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxJarClient _taxJarClient;

        public TaxService(ITaxJarClient taxJarClient)
        {
            _taxJarClient = taxJarClient;
        }

        public async Task<string> CalculateTaxForOrder(decimal amount, decimal shipping, string toZip, string toState, string fromZip, string fromState)
        {
            var request = ToOrderRequest(amount, shipping, toZip, toState, fromZip, fromState);

            var response = await _taxJarClient.CalculateOrderTax(request)
                .ConfigureAwait(false);

            return FormatAmountToCollect(response.Tax.AmountToCollect);
        }

        public async Task<(string City, string Rate)> GetRateForZip(string zipCode)
        {
            var result = await _taxJarClient.GetLocationTaxRate(zipCode)
                .ConfigureAwait(false);

            return (City: FormatCity(result.Rate.City), Rate: FormatRate(result.Rate.CombinedRate));
        }

        private static string FormatAmountToCollect(decimal amount) => amount.ToString("C");
        private static string FormatCity(string city) => string.IsNullOrWhiteSpace(city) ? "Unknown" : city;
        private static string FormatRate(decimal rate) => $"{rate * 100} %";

        private static OrderRequest ToOrderRequest(decimal amount, decimal shipping, string toZip, string toState, string fromZip, string fromState)
        {
            return new OrderRequest
            {
                ToState = toState,
                ToZip = toZip,
                FromState = fromState,
                FromZip = fromZip,
                ToCountry = "US",
                FromCountry = "US",
                Amount = amount,
                Shipping = shipping,
            };
        }
    }
}
