using System.Threading.Tasks;
using TaxCalculator.Http;
using TaxCalculator.Models.TaxJar;

namespace TaxCalculator.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxJarClient _taxJarClient;

        public TaxService(ITaxJarClient taxJarClient)
        {
            _taxJarClient = taxJarClient;
        }

        public async Task<decimal> CalculateTaxForOrder(decimal amount, decimal shipping, string toZip, string toState, string fromZip, string fromState)
        {
            var request = new OrderRequest
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

            var response = await _taxJarClient.CalculateOrderTax(request);
            return response.Tax.AmountToCollect;
        }

        public async Task<(string City, decimal Rate)> GetRateForZip(string zipCode)
        {
            var result = await _taxJarClient.GetLocationTaxRate(zipCode);
            return (result.Rate.City, result.Rate.CombinedRate);
        }
    }
}
