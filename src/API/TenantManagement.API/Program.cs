
using MongoDB.Driver;
using TenantManagement.Application.Interfaces;
using TenantManagement.Application.Services;
using TenantManagement.Domain.Interfaces;
using TenantManagement.Infrastructure.Events;
using TenantManagement.Infrastructure.Repositories;

namespace TenantManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("SaaSLoyalty");

            // Register application services, domain services, and infrastructure services
            builder.Services.AddSingleton<IMongoDatabase>(database);
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            builder.Services.AddScoped<ITenantRepository, TenantRepository>();
            builder.Services.AddScoped<ITenantService, TenantService>();
            // Register event handlers and dispatchers
            builder.Services.AddScoped<IEventDispatcher, EventDispatcher>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tenant Management API V1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
