using Infrastructure.SharedKernel.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FiapTechChallenge.SharedKernel.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // 1) configura JwtSettings em IOptions<JwtSettings>
            services.Configure<JwtSettings>(
                configuration.GetSection("JwtSettings"));

            // 2) registra o gerador de token
            //services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            // 3) middleware de autenticação
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts =>
                {
                    var jwt = configuration.GetSection("JwtSettings")
                                           .Get<JwtSettings>();
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwt.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwt.Audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                                                      Encoding.UTF8.GetBytes(jwt.Secret))
                    };
                });

            return services;
        }
    }
}
