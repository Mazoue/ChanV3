using Models.Settings;
using Services.Interfaces;

namespace Services.Services
{
    public class GeneralConfigService : IGeneralConfigService
    {
        private readonly bool _showImagePreview;
        private readonly bool _showWorkSafeOnly;
        private readonly string _logBasePath;

        public GeneralConfigService(GeneralConfig generalConfig)
        {
            _showImagePreview = generalConfig.ShowImagePreview;
            _showImagePreview = generalConfig.WorkSafeOnlyBoards;
            _logBasePath = generalConfig.LogBasePath;
        }

        public bool ShowImagePreview() => _showImagePreview;
        public bool ShowWorkSafeOnlyBoards() => _showWorkSafeOnly;
        public string LogBasePath() => _logBasePath;
    }
}
