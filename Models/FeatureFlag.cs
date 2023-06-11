using MessagePack;

namespace MortgageMoniteringSystem.Models
{
    public class FeatureFlag
    {
        public int UniqueId { get; set; }
        public string? Label { get; set; }   
        public string? FeatureId { get; set; }
        public string? FeatureName { get; set; }
        public string? FeatureDescription { get; set; }

    }
}
