using BusinessLogic.Helper.Authentication;
using BusinessLogic.Helper.Interface;
using BusinessLogic.Helper.Logics;
using Mapping.Section;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MyApp.db.Interfaces;
using MyApp.db.SqlFunctions;
using MyHelping.Section.Conversion;
using MyHelping.Section.interfaces;
using System.Text;

namespace Intigators.SentientGeeks_Test
{
    internal static class intigators
    {
        public static WebApplicationBuilder Interfaceregister(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IEncryption, Encryption>();
            builder.Services.AddTransient<IBalEmployee, BalEmployee>();
            builder.Services.AddTransient<IBalAuthorizeUser, BalAuthorizeUser>();
            builder.Services.AddTransient<ILogin, Login>();
            builder.Services.AddTransient<IAuth, Auth>();
            builder.Services.AddTransient<IEmployeeLogic, EmployeeLogic>();

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,


                        ValidIssuer = "*",
                        ValidAudience = "*",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:secretkey"]))

                    };
                });


            builder.Services.AddAutoMapper(typeof(AutoMappingProfile).Assembly);
            return builder;
        }
    }
}
