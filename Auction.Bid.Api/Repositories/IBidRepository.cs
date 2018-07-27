using Auction.Bid.Api.Controllers.ViewModels;
using Auction.Bid.Api.Models;
using Auction.Common.Data.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Bid.Api.Repositories
{
    public interface IBidRepository: IRepositoryBase<BidEntity>
    {
        Task<IEnumerable<BidEntity>> GetBidsByUserId(string userId);
        Task<BidEntity> GetHighestBidOfProduct(string productId, DateTimeOffset dateTimeOffset);
        IEnumerable<BidEntity> GetHighestBids(IEnumerable<SimpleProductModel> productIds);
    }
}
