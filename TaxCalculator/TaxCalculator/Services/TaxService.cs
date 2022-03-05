using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.Http;

namespace TaxCalculator.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxJarClient _taxJarClient;

        public TaxService(ITaxJarClient taxJarClient)
        {
            _taxJarClient = taxJarClient;
        }

        public async Task<List<decimal>> GetRatesForZip(string zipCode)
        {
            var rateResults = await _taxJarClient.GetLocationTaxRates(zipCode);
            return rateResults.Rates.Select(x => x.CombinedRate).ToList();
        }
    }
}
