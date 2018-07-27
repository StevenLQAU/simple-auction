using Auction.Bid.Api.Controllers.ViewModels;
using Auction.Bid.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Bid.Api.Services
{
    public interface IBidService
    {
        Task<BidModel> CreateBid(BidModel model);
        Task<IEnumerable<BidEntity>> GetBidsByUserId(string userId);
        Task<BidEntity> GetHighestBidOfProduct(string productId, DateTimeOffset dateTimeOffset);
        IEnumerable<BidEntity> GetHighestBids(IEnumerable<SimpleProductModel> products);
    }
}
