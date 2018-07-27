using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Bid.Api.Repositories;
using Auction.Bid.Api.Repositories.Impl;
using Auction.Bid.Api.Services;
using Auction.Bid.Api.Services.Impl;
using Auction.Common.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Auction.Bid.Api
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
            services.RegisterMongoDbSettings(Configuration);
            services.AddTransient<IBidService, BidService>();
            services.AddTransient<IBidRepository, BidRepository>();



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                IBidRepository bidRepository = serviceProvider.GetService<IBidRepository>();
                bidRepository.Db.DropCollection("bids");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
