using FluentAssertions;
using TaxCalculator.Shared.Helpers;
using Xunit;

namespace TaxCalculator.Shared.UnitTests
{
    public class LocationHelperTests
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("123", false)]
        [InlineData("1234", false)]
        [InlineData("12345", true)]
        [InlineData("32213", true)]
        [InlineData("22222", true)]
        public void IsValidZip_ReturnsExpected(string zip, bool expected)
        {
            var isValid = LocationHelper.IsValidZip(zip);
            isValid.Should().Be(expected);
        }

        [Theory]
        [InlineData(null, null, null, null, false)]
        [InlineData("", "", "", "", false)]
        [InlineData("123", "123", "CA", "CA", false)]
        [InlineData("43234", "34234", "CA", "CA", true)]
        [InlineData("98765", "92467", "FL", "FL", true)]
        public void IsValidLocation_ReturnsExpected(string toZip, string fromZip, string toState, string fromState, bool expected)
        {
            var isValid = LocationHelper.IsValidLocation(toZip, toState, fromZip, fromState);
            isValid.Should().Be(expected);
        }
    }
}
