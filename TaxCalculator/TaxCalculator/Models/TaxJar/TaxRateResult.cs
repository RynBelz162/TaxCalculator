using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TaxCalculator.Models.TaxJar
{
    public class TaxRateResult
    {
        [JsonPropertyName("rate")]
        public ICollection<TaxRate> Rates { get; init; }
    }
}
