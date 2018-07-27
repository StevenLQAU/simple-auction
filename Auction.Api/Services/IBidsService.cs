using Auction.Common.Models.Bids;
using Auction.Common.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.Services
{
    public interface IBidsService
    {
        Task<BidModel> CreateBid(BidModel bidModel);
        Task<IEnumerable<ProductBidModel>> GetProducts();
    }
}
