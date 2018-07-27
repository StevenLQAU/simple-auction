using Auction.Common.Data;
using Auction.Common.Data.MongoDB.Impl;
using Auction.Product.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Product.Api.Repositories.Impl
{
    public class ProductRepository: RepositoryBase<ProductEntity>, IProductRepository
    {
        public ProductRepository(IOptions<MongoSetting> settings) : base(settings, "products")
        {

        }

        public async Task CreateSample()
        {
            await Create(new ProductEntity
            {
                StartTime = DateTimeOffset.Now,
                CloseTime = DateTimeOffset.Now.AddMinutes(30),
                Name = "Ps4",
                Status = ProductStatus.NotStart
            });

            await Create(new ProductEntity
            {
                StartTime = DateTimeOffset.Now.AddMinutes(2),
                CloseTime = DateTimeOffset.Now.AddMinutes(9),
                Name = "Switch",
                Status = ProductStatus.NotStart
            });

            await Create(new ProductEntity
            {
                StartTime = DateTimeOffset.Now.AddMinutes(3),
                CloseTime = DateTimeOffset.Now.AddMinutes(8),
                Name = "XBoxOne",
                Status = ProductStatus.NotStart
            });
        }

        public async Task<IEnumerable<ProductEntity>> GetAll(IEnumerable<ProductStatus> status)
        {
            return await Collection.Find(p => status.Contains(p.Status)).ToListAsync();
        }
    }
}
