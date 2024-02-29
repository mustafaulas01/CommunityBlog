using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServivces(this IServiceCollection services, IConfiguration config)
        {

            // Add services to the container.

            services.AddControllers();

            services.AddScoped<AstralContext>();
            services.AddScoped<IUserInterface, UserManager>();
            services.AddScoped<ITokenService, TokenManager>();

            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(option =>
              {
                  option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                      ValidateIssuer = false,
                      ValidateAudience = false
                  };

              });

           
           return services;
        }

    }
}