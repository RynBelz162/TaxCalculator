namespace TaxCalculator.Shared.Helpers
{
    public static class LocationHelper
    {
        public static bool IsValidLocation(string toZip, string toState, string fromZip, string fromState)
        {
            return
                IsValidZip(toZip)
                && IsValidZip(fromZip)
                && !string.IsNullOrWhiteSpace(toState)
                && !string.IsNullOrWhiteSpace(fromState);
        }

        public static bool IsValidZip(string zip) => !string.IsNullOrWhiteSpace(zip) && zip.Length == 5;
    }
}
