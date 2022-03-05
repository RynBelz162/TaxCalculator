using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaxCalculator.Services
{
    public interface ITaxService
    {
        Task<List<decimal>> GetRatesForZip(string zipCode);
    }
}
