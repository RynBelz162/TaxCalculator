using System.Text.Json.Serialization;

namespace TaxCalculator.Shared.Models.TaxJar
{
    public class OrderResponse
    {
        [JsonPropertyName("tax")]
        public Tax Tax { get; init; }
    }
}
