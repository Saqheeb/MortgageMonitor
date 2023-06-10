
using Azure.Data.AppConfiguration;
using System.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MortgageMoniteringSystem.Services
{
    public class FeatureManagementService : IFeatureManagementService
    {
        private const string AZURE_APP_CONFIG_KEY_IDENTIFIER = ".appconfig.featureflag";

        private const string AZURE_FEATURE_MANAGEMENT_CONTENT_TYPE = "application/vnd.microsoft.appconfig.ff+json;charset=utf-8";

        internal class FeatureFlagModel
        {
            [JsonPropertyName("id")]
            public string? Id { get; set; }

            [JsonPropertyName("description")]
            public string? Description { get; set; }

            [JsonPropertyName("enabled")]
            public bool? Enabled { get; set; }

            [JsonPropertyName("conditions")]
            public object? Conditions { get; set; }
        }

        public string Label { get; init; }

        private readonly ConfigurationClient client;

        public FeatureManagementService(string connectionStr, string label)
        {
            client = new ConfigurationClient(connectionStr);

            Label = label;
        }

        public bool GetFlagStatus(string featureFlagId)
        {
            var key = GetAppConfigFeatureFlagKey(featureFlagId);

            var configSettings = GetAppConfigFeatureFlagSetting(key, string.Empty, Label);

            var response = client.GetConfigurationSetting(configSettings);

            var model = JsonSerializer.Deserialize<FeatureFlagModel>(response.Value.Value);

            return (bool)model.Enabled;
        }

        public void SetFlagStatus(string featureFlagId, bool isEnabled)
        {
            var key = GetAppConfigFeatureFlagKey(featureFlagId);

            var model = new FeatureFlagModel
            {
                Id = featureFlagId,
                Description = FeatureConstants.GetDescription(featureFlagId),
                Enabled = isEnabled,
                Conditions = default
            };

            var value = JsonSerializer.Serialize(model);

            var configSettings = GetAppConfigFeatureFlagSetting(key, value, Label);

            client.SetConfigurationSetting(configSettings);
        }

        private static string GetAppConfigFeatureFlagKey(string featureFlagId) =>
        $"{AZURE_APP_CONFIG_KEY_IDENTIFIER}/{featureFlagId}";

        private static ConfigurationSetting GetAppConfigFeatureFlagSetting(
            string key, string value, string label) =>
            new(key, value, label)
            {
                ContentType = AZURE_FEATURE_MANAGEMENT_CONTENT_TYPE
            };
    }
}
