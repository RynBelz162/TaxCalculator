using System.Threading.Tasks;
using TaxCalculator.Models.TaxJar;

namespace TaxCalculator.Http
{
    public interface ITaxJarClient
    {
        Task<TaxRateResult> GetLocationTaxRates(string zip);
        Task<OrderResponse> CalculateOrderTax(OrderRequest request);
    }
}
