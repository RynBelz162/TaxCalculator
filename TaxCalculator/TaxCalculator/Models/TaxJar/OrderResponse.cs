using System.Text.Json.Serialization;

namespace TaxCalculator.Models.TaxJar
{
    public class OrderResponse
    {
        [JsonPropertyName("tax")]
        public Tax Tax { get; init; }
    }
}
