using System.Text.Json.Serialization;

namespace TaxCalculator.Models.TaxJar
{
    public record OrderResponse
    (
        [property:JsonPropertyName("order_total_amount")]
        decimal OrderTotalAmount,

        [property:JsonPropertyName("shipping")]
        decimal Shipping,

        [property:JsonPropertyName("taxable_amount")]
        decimal TaxableAmount,

        [property:JsonPropertyName("amount_to_collect")]
        decimal AmountToCollect,

        [property:JsonPropertyName("rate")]
        decimal Rate,

        [property:JsonPropertyName("has_nexus")]
        bool HasNexus,

        [property:JsonPropertyName("freight_taxable")]
        bool FreightTaxable,

        [property:JsonPropertyName("tax_source")]
        string TaxSource
    ) { }
}
