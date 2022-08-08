using Services.Interfaces;

namespace Services.Services
{
    public class LogService : ILogService
    {
        private readonly IGeneralConfigService _generalConfigService;
        public LogService(IGeneralConfigService generalConfigService) => _generalConfigService = generalConfigService;
        public async Task WriteError(Exception exception)
        {
            var logLocation = ConfirmOrCreateFilePath(_generalConfigService.LogBasePath(), "ErrorLog.txt");

            await using(var errorLogWriter = File.AppendText(logLocation))
            {
                errorLogWriter.WriteLine($"Exception Time:{DateTime.Now}");
                errorLogWriter.WriteLine($"Exception Type:{exception.GetType()}");
                errorLogWriter.WriteLine($"Exception Message:{exception.Message}");
            }
        }

        private string ConfirmOrCreateFilePath(string filePath, string fileName)
        {
            if(!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            var fileLocation = Path.Combine(filePath, fileName);

            if(!File.Exists(fileLocation))
                File.Create(fileLocation);

            return fileLocation;

        }
    }
}
