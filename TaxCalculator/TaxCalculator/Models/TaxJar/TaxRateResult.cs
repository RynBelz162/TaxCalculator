using System.Text.Json.Serialization;

namespace TaxCalculator.Models.TaxJar
{
    public class TaxRateResult
    {
        [JsonPropertyName("rate")]
        public TaxRate Rate { get; init; }
    }
}
