using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Api.ExternalServices;
using Auction.Api.ExternalServices.Impl;
using Auction.Api.Jwt;
using Auction.Api.Services;
using Auction.Api.Services.Impl;
using Auction.Api.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Auction.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<JwtOptions>(options =>
            {
                options.Issuer = Configuration.GetSection("JwtOptions:Issuer").Value;
                options.Audience = Configuration.GetSection("JwtOptions:Audience").Value;
                options.Key = Configuration.GetSection("JwtOptions:Key").Value;
            });

            services.Configure<ExternalEndpointOptions>(options =>
            {
                options.BidApiUrl = Configuration.GetSection("ServiceEndPoints:BidApi").Value;
                options.ProductApiUrl = Configuration.GetSection("ServiceEndPoints:ProductApi").Value;
                options.UserApiUrl = Configuration.GetSection("ServiceEndPoints:UserApi").Value;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JwtOptions:Key").Value)),

                    ValidateIssuer = true,
                    ValidIssuer = Configuration.GetSection("JwtOptions:Issuer").Value,

                    ValidateAudience = true,
                    ValidAudience = Configuration.GetSection("JwtOptions:Audience").Value,

                    ValidateLifetime = true, //validate the expiration and not before values in the token

                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            services.AddTransient<IExternalService, ExternalService>();
            services.AddTransient<ISignalRNotifier, SignalRNotifier>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IBidsService, BidsService>();


            services.AddCors();
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();

            //Allow * for cors, easy for testing
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseSignalR(routes =>
            {
                routes.MapHub<SignalRNotifier>("/bidsHub");
            });
            app.UseMvc();
        }
    }
}
