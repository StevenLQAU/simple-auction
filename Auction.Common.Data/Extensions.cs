using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Common.Data
{
    public static class Extensions
    {
        public static void RegisterMongoDbSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSetting>(options =>
            {
                options.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.DatabaseName = configuration.GetSection("MongoConnection:Database").Value;
            });
        }
    }
}
