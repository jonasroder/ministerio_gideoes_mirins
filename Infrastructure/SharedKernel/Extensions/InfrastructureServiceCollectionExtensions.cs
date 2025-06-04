using Infrastructure.SharedKernel.Logger;
using Infrastructure.SharedKernel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SharedKernel.Extensions;
public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseNpgsql(config.GetConnectionString("DefaultConnection")),
            ServiceLifetime.Scoped);

        services.AddScoped<ICorrelationIdGenerator, CorrelationIdGenerator>();
        services.AddScoped(typeof(BaseLogger<>));

        //services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
       

        return services;
    }
}