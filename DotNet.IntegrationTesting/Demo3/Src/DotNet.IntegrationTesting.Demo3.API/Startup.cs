namespace DotNet.IntegrationTesting.Demo3.API
{
    using DotNet.IntegrationTesting.Demo3.API.Utils;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDatabaseContext(Configuration);
            services.AddInfrastructureDependencies();
            services.AddApplicationDependencies();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.CreateDbIfNotExists();
        }
    }
}
