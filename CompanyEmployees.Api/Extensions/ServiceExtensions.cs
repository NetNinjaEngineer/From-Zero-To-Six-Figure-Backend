using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories;
using Service;
using Service.Contracts;

namespace CompanyEmployees.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", options =>
            options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });

        services.Configure<IISOptions>(options =>
        {

        });

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddAutoMapper(typeof(MappingProfile));

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        return services;
    }
}