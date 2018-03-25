using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wardrobe.DataAccess.Context;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.DataAccess.Repository;
using Wardrobe.Service.Test.Controller;

namespace TestRunnerSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = setupApplication();

            var test = new LocationControllerTests(serviceProvider.GetService<IWardrobeRepository>(), null);
            test.LocationController_Get_ReturnsElements();
            test.LocationController_Post_AddsNewElement();
            test.LocationController_Put_UpdatesElement();
            test.LocationController_Delete_RemovesElement();

            Console.ReadKey();
        }

        private static IServiceProvider setupApplication()
        {
            return new ServiceCollection()
                .AddLogging()
                .AddTransient<IWardrobeRepository, WardrobeRepository>()
                .AddDbContext<WardrobeDataContext>(options => options.UseSqlServer(ConfigurationManager.ConnectionStrings["DatabaseName"].ConnectionString))
                .BuildServiceProvider();
        }
    }
}
