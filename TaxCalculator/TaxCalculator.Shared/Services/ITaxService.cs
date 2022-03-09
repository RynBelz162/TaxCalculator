using System.Threading.Tasks;

namespace TaxCalculator.Shared.Services
{
    public interface ITaxService
    {
        Task<(string City, string Rate)> GetRateForZip(string zipCode);
        Task<string> CalculateTaxForOrder(decimal amount, decimal shipping, string toZip, string toState, string fromZip, string fromState);
    }
}
