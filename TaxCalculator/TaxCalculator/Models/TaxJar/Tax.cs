using System.Text.Json.Serialization;

namespace TaxCalculator.Models.TaxJar
{
    public record Tax
    {
        [JsonPropertyName("order_total_amount")]
        public decimal OrderTotalAmount { get; init; }

        [JsonPropertyName("shipping")]
        public decimal Shipping { get; init; }

        [JsonPropertyName("taxable_amount")]
        public decimal TaxableAmount { get; init; }

        [JsonPropertyName("amount_to_collect")]
        public decimal AmountToCollect { get; init; }

        [JsonPropertyName("rate")]
        public decimal Rate { get; init; }

        [JsonPropertyName("has_nexus")]
        public bool HasNexus { get; init; }

        [JsonPropertyName("freight_taxable")]
        public bool FreightTaxable { get; init; }

        [JsonPropertyName("tax_source")]
        public string TaxSource { get; init; }
    }
}
