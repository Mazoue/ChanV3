using Models.Settings;
using Services.Interfaces;
using Services.Services;

namespace ChanV3.Startup
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, GeneralConfig generalConfig)
        {
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<IDownloadService, DownloadService>();
            services.AddSingleton<IGeneralConfigService>(e => new GeneralConfigService(generalConfig));
            services.AddSingleton<ILogService, LogService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IThreadService, ThreadService>();
            return services;
        }
    }
}
