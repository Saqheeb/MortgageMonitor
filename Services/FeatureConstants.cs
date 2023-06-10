using System.ComponentModel;
using System.Reflection;

namespace MortgageMoniteringSystem.Services
{
    public static class FeatureConstants
    {
        [Description("Enables client registration journey if selected otherwise disables.")]
        public const string FeatureEnableClientRegistration = "Feature-EnableClientRegistration";

        public static string GetDescription(string featureFlagId)
        {
            var comparer = StringComparison.InvariantCultureIgnoreCase;

            var featureFieldInfo = typeof(FeatureConstants)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .SingleOrDefault(f => featureFlagId.Equals((string?)f.GetValue(null), comparer));

            var featureDescription = featureFieldInfo?
                .GetCustomAttribute<DescriptionAttribute>(true)?
                .Description ?? string.Empty;

            return featureDescription;
        }
    }
}
