using System.Text.Json.Serialization;

namespace TaxCalculator.Shared.Models.TaxJar
{
    public record OrderRequest
    {
        [JsonPropertyName("to_country")]
        public string ToCountry { get; init; }

        [JsonPropertyName("to_zip")]
        public string ToZip { get; init; }

        [JsonPropertyName("to_state")]
        public string ToState { get; init; }

        [JsonPropertyName("from_country")]
        public string FromCountry { get; init; }

        [JsonPropertyName("from_zip")]
        public string FromZip { get; init; }

        [JsonPropertyName("from_state")]
        public string FromState { get; init; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; init; }

        [JsonPropertyName("shipping")]
        public decimal Shipping { get; init; }
    }
}
