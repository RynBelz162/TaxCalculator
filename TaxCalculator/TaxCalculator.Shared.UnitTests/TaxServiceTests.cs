using FluentAssertions;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using TaxCalculator.Shared.Http;
using TaxCalculator.Shared.Models.TaxJar;
using TaxCalculator.Shared.Services;
using Xunit;

namespace TaxCalculator.Shared.UnitTests
{
    public class TaxServiceTests
    {
        private readonly TaxService _taxService;
        private readonly Mock<ITaxJarClient> _taxjarClient;

        public TaxServiceTests()
        {
            var autoMocker = new AutoMocker();
            _taxService = autoMocker.CreateInstance<TaxService>();
            _taxjarClient = autoMocker.GetMock<ITaxJarClient>();
        }

        [Theory]
        [InlineData(10, "$10.00")]
        [InlineData(5.55, "$5.55")]
        [InlineData(0, "$0.00")]
        [InlineData(999.999, "$1,000.00")]
        [InlineData(49.639, "$49.64")]
        public async Task CalculateTaxForOrder_ReturnsFormattedMoney(decimal amount, string expected)
        {
            _taxjarClient.Setup(x => x.CalculateOrderTax(It.IsAny<OrderRequest>()))
                .ReturnsAsync(CreateMockOrderResponse(amount));

            var result = await _taxService.CalculateTaxForOrder(100.0m, 10m, "33572", "FL", "32095", "FL");

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("NYC", 0.09, "NYC", "9.00 %")]
        [InlineData("Toledo", 0.075, "Toledo", "7.500 %")]
        [InlineData("", 0.237, "Unknown", "23.700 %")]
        [InlineData(null, 0.00, "Unknown", "0 %")]
        [InlineData("Tampa", 0.065, "Tampa", "6.500 %")]
        public async Task GetRateForZip_ReturnsFormatedCityAndRate(string city, decimal rate, string expectedCity, string expectedRate)
        {
            _taxjarClient.Setup(x => x.GetLocationTaxRate(It.IsAny<string>()))
                .ReturnsAsync(CreateMockTaxResultResponse(city, rate));

            var (City, Rate) = await _taxService.GetRateForZip(It.IsAny<string>());

            City.Should().Be(expectedCity);
            Rate.Should().Be(expectedRate);
        }

        private static OrderResponse CreateMockOrderResponse(decimal amountToCollect)
        {
            return new OrderResponse
            {
                Tax = new Tax
                {
                    AmountToCollect = amountToCollect,
                }
            };
        }

        private static TaxRateResult CreateMockTaxResultResponse(string city, decimal rate)
        {
            return new TaxRateResult
            {
                Rate = new TaxRate
                {
                    CombinedRate = rate,
                    City = city,
                }
            };
        }
    }
}
