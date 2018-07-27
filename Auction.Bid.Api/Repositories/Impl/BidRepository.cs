using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Bid.Api.Controllers.ViewModels;
using Auction.Bid.Api.Models;
using Auction.Common.Data;
using Auction.Common.Data.MongoDB.Impl;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Auction.Bid.Api.Repositories.Impl
{
    public class BidRepository : RepositoryBase<BidEntity>, IBidRepository
    {
        public BidRepository(IOptions<MongoSetting> settings) : base(settings, "bids")
        {

        }

        public async Task<IEnumerable<BidEntity>> GetBidsByUserId(string userId)
        {
            return await Collection.Find<BidEntity>(entity => entity.UserId == userId).ToListAsync();
        }

        public async Task<BidEntity> GetHighestBidOfProduct(string productId, DateTimeOffset dateTimeOffset)
        {
            return await Collection.Find(entity => entity.ProductId == productId && entity.CreateTime < dateTimeOffset)
                .SortByDescending(entity => entity.Amount)
                .FirstOrDefaultAsync();
        }

        public IEnumerable<BidEntity> GetHighestBids(IEnumerable<SimpleProductModel> products)
        {
            List<BidEntity> results = new List<BidEntity>();
            var ids = products.Select(p => p.Id);
            //var groups = Collection.AsQueryable()
            //    .Where(x => ids.Contains(x.ProductId))
            //    .GroupBy(x => x.ProductId);

            var list = Collection.Find(x => ids.Contains(x.ProductId)).SortByDescending(x=>x.Amount).ToList();
            var groups = list.GroupBy(x => x.ProductId);


            foreach (var group in groups)
            {
                var product = products.First(p => p.Id == group.Key);
                var bid = group.Where(x => x.CreateTime < product.CloseTime && x.CreateTime > product.StartTime).FirstOrDefault();
                if(bid != null)
                {
                    results.Add(bid);
                }
            }
            return results;
        }
    }
}
