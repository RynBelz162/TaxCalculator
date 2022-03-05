using System.Text.Json.Serialization;

namespace TaxCalculator.Models.TaxJar
{
    public record TaxRate 
    (
        string Zip,

        string State,

        [property:JsonPropertyName("state_rate")]
        decimal StateRate,

        string County,

        [property:JsonPropertyName("county_rate")]
        decimal CountyRate,

        string City,

        [property:JsonPropertyName("city_rate")]
        decimal CityRate,

        [property:JsonPropertyName("combined_district_rate")]
        decimal CombinedDistrictRate,

        [property:JsonPropertyName("combined_rate")]
        decimal CombinedRate
    ) { }
}
