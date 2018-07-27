using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Bid.Api.Controllers.ViewModels;
using Auction.Bid.Api.Models;
using Auction.Bid.Api.Repositories;

namespace Auction.Bid.Api.Services.Impl
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }


        public async Task<BidModel> CreateBid(BidModel model)
        {
            var bidEntity = BidEntity.Create(model);
            await _bidRepository.Create(bidEntity);
            return new BidModel(bidEntity);
        }

        public async Task<IEnumerable<BidEntity>> GetBidsByUserId(string userId)
        {
            return await _bidRepository.GetBidsByUserId(userId);
        }

        public async Task<BidEntity> GetHighestBidOfProduct(string productId, DateTimeOffset dateTimeOffset)
        {
            return await _bidRepository.GetHighestBidOfProduct(productId, dateTimeOffset);
        }

        public IEnumerable<BidEntity> GetHighestBids(IEnumerable<SimpleProductModel> products)
        {
            return _bidRepository.GetHighestBids(products);
        }
    }
}
