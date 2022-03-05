using System.Text.Json.Serialization;

namespace TaxCalculator.Models.TaxJar
{
    public record OrderRequest
    {
        [JsonPropertyName("to_country")]
        public string ToCountry { get; init; }

        [JsonPropertyName("to_zip")]
        public string ToZip { get; init; }

        [JsonPropertyName("to_state")]
        public string ToState { get; init; }

        public decimal Amount { get; init; }

        public decimal Shipping { get; init; }
    }
}
