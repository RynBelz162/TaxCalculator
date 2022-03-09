using System.Threading.Tasks;
using TaxCalculator.Shared.Models.TaxJar;

namespace TaxCalculator.Shared.Http
{
    public interface ITaxJarClient
    {
        Task<TaxRateResult> GetLocationTaxRate(string zip);
        Task<OrderResponse> CalculateOrderTax(OrderRequest request);
    }
}
