using ChanV3.Startup;
using Models.Settings;

namespace Chanv3.Startup
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            var apiConfig = new ChanApiConfig()
            {
                BoardBase = Configuration.GetSection("4ChanBaseUrls")["BoardBase"],
                ImageBase = Configuration.GetSection("4ChanBaseUrls")["ImageBase"]
            };

            var fileSystemConfig = new FileSystemConfig()
            {
                BaseFolder = Configuration.GetSection("FileSystemConfig")["BaseFolder"]
            };

            var generalConfig = new GeneralConfig()
            {
                ShowImagePreview = Convert.ToBoolean(Configuration.GetSection("GeneralConfig")["ShowImagePreview"]),
                WorkSafeOnlyBoards = Convert.ToBoolean(Configuration.GetSection("GeneralConfig")["WorkSafeOnlyBoards"]),
                LogBasePath = Configuration.GetSection("GeneralConfig")["LogBasePath"]
            };

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.RegisterServices(generalConfig);
            services.RegisterRepositories(apiConfig, fileSystemConfig);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}