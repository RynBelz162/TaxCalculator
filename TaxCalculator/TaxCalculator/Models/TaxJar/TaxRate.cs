using System.Text.Json.Serialization;

namespace TaxCalculator.Models.TaxJar
{
    public record TaxRate
    {
        public string Zip { get; init; }

        public string State { get; init; }

        [JsonPropertyName("state_rate")]
        public decimal StateRate { get; init; }

        public string County { get; init; }

        [JsonPropertyName("county_rate")]
        public decimal CountyRate { get; init; }

        public string City { get; init; }

        [JsonPropertyName("city_rate")]
        public decimal CityRate { get; init; }

        [JsonPropertyName("combined_district_rate")]
        public decimal CombinedDistrictRate { get; init; }

        [JsonPropertyName("combined_rate")]
        public decimal CombinedRate { get; init; }
    }
}
