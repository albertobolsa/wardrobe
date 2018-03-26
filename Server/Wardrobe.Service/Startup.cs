using System.Net;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Wardrobe.DataAccess.Context;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.DataAccess.Repository;
using Wardrobe.Service.Exceptions;
using Wardrobe.Service.Filters;
using Wardrobe.Service.Interfaces;
using Wardrobe.Service.Service;

namespace Wardrobe.Service
{
    public class Startup
    {
        private const string CONNECTION_STRING_KEY = "DatabaseName";
        private readonly ILoggerFactory _loggerFactory;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvc();
            services.AddTransient<IWardrobeRepository, WardrobeRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<ILoggingRepository, LoggingRepository>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IClothingItemService, ClothingItemService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<ILoggingService, LoggingService>();
            services.AddDbContext<WardrobeDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString(CONNECTION_STRING_KEY)));
            services.AddDbContext<ImageDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString(CONNECTION_STRING_KEY)));
            services.AddDbContext<LogDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString(CONNECTION_STRING_KEY)));

            builder.AddMvcOptions(o => { o.Filters.Add(new GlobalExceptionFilter(_loggerFactory)); });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(exceptionAction);
            app.UseMvc();
        }

        private void exceptionAction(IApplicationBuilder builder)
        {
            builder.Run(async context =>
            {
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var exception = context.Features.Get<IExceptionHandlerFeature>();
                if (exception != null)
                {
                    var error = JsonConvert.SerializeObject(new AppError(message: exception.Error.Message, stacktrace: exception.Error.StackTrace));
                    await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(error), 0, error.Length).ConfigureAwait(false);
                }
            });
        }
    }
}
