using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HwAspNetCoreBlazor.Data;
using Microsoft.Extensions.Logging;

namespace HwAspNetCoreBlazor.Tests.IntegrationTests
{
    public class TestAPIFactory<T> : WebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

                var provider = services.AddDbContext<HwAspNetCoreBlazorDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TestingDb");
                    options.UseInternalServiceProvider(serviceProvider);
                }).BuildServiceProvider();


                using (var scope = provider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var database = scopedServices.GetRequiredService<HwAspNetCoreBlazorDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<TestAPIFactory<T>>>();


                    database.Database.EnsureCreated();

                    try
                    {
                        HwAspNetCoreBlazorDbInitializer.Initialize(scopedServices);
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, "Error occured while seeding the db. " + e.Message);
                    }
                }
            });
        }
    }
}
