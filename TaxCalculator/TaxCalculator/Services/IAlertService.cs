using System.Threading.Tasks;

namespace TaxCalculator.Services
{
    public interface IAlertService
    {
        Task ShowAsync(string message);
    }
}
