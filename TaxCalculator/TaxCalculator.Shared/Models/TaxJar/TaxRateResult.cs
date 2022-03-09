using System.Text.Json.Serialization;

namespace TaxCalculator.Shared.Models.TaxJar
{
    public class TaxRateResult
    {
        [JsonPropertyName("rate")]
        public TaxRate Rate { get; init; }
    }
}
