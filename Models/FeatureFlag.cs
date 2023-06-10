using MessagePack;

namespace MortgageMoniteringSystem.Models
{
    public class FeatureFlag
    {
        public int FeatureId { get; set; }
        public string? FeatureName { get; set; }
        public string? FeatureDescription { get; set; }

    }
}
