using System.Threading.Tasks;

namespace TaxCalculator.Services
{
    public interface ITaxService
    {
        Task<(string City, decimal Rate)> GetRateForZip(string zipCode);
        Task<decimal> CalculateTaxForOrder(decimal amount, decimal shipping, string toZip, string toState, string fromZip, string fromState);
    }
}
