namespace MortgageMoniteringSystem.Services
{
    public interface IFeatureManagementService
    {
        bool GetFlagStatus(string featureFlagId);
        void SetFlagStatus(string featureFlagId, bool isEnabled);
    }
}