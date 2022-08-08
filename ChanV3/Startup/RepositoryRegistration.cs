using DataAccess.Interfaces;
using DataAccess.Repositories;
using Models.Settings;

namespace ChanV3.Startup
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services, ChanApiConfig chanApiConfig, FileSystemConfig fileSystemConfig)
        {
            services.AddHttpClient<IBoardRepository, BoardRepository>(client =>
            {
                client.BaseAddress = new Uri(chanApiConfig.BoardBase);
            });

            services.AddHttpClient<IContentRepository, ContentRepository>(client =>
            {
                client.BaseAddress = new Uri(chanApiConfig.ImageBase);
            });

            services.AddHttpClient<IPostRepository, PostRepository>(client =>
            {
                client.BaseAddress = new Uri(chanApiConfig.BoardBase);
            });

            services.AddScoped<IFileSystemRepository>(client => new FileSystemRepository(fileSystemConfig.BaseFolder));

            return services;
        }
    }
}
