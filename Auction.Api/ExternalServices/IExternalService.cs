using Auction.Common.Models.Bids;
using Auction.Common.Models.Products;
using Auction.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.ExternalServices
{
    public interface IExternalService
    {
        Task<string> ValidateUser(LoginModel model);
        Task<IEnumerable<ProductModel>> GetProducts(int status = 0);
        Task<BidModel> GetBids(string userId);
        Task<BidModel> CreateBid(BidModel bid);
        Task<BidModel> GetHighestBidOfProduct(SimpleProductModel product);
        Task<IEnumerable<BidModel>> GetHighestBids(IEnumerable<SimpleProductModel> products);
        Task<ProductModel> UpdateProduct(ProductModel model);

    }
}
