using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Wardrobe.DataAccess.Context;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.DataAccess.Repository;
using Wardrobe.Service.Filters;
using Wardrobe.Service.Interfaces;
using Wardrobe.Service.Service;

namespace Wardrobe.Service
{
    public class Startup
    {
        private readonly ILoggerFactory _loggerFactory;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvc();
            services.AddTransient<IWardrobeRepository, WardrobeRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IClothingItemService, ClothingItemService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<ILoggingService, LoggingService>();
            services.AddDbContext<WardrobeDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseName")));
            services.AddDbContext<ImageDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseName")));
            services.AddDbContext<LogDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseName")));

            builder.AddMvcOptions(o => { o.Filters.Add(new GlobalExceptionFilter(_loggerFactory)); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            
        }
    }
}
