using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Auction.Bid.Api.Controllers.ViewModels;
using Auction.Bid.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Bid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpPost]
        public async Task<BidModel> Create(BidModel model)
        {
            var result = await _bidService.CreateBid(model);
          
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<BidModel>> GetBids(string userId)
        {
            var bids = await _bidService.GetBidsByUserId(userId);
            return bids.Select(bid => new BidModel(bid));
        }

        [HttpPost]
        [Route("Product")]
        public async Task<BidModel> GetHighestBidOfProduct(SimpleProductModel model)//, string format = "yyyyMMddhhmmssZ")
        {
            //DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
            //DateTime datetime = unixEpoch.AddSeconds(timestamp);

            //var date = DateTimeOffset.ParseExact(dateTimeOffset, format, CultureInfo.InvariantCulture);
            var bid = await _bidService.GetHighestBidOfProduct(model.Id, model.CloseTime);
            return new BidModel(bid);
        }

        [HttpPost]
        [Route("Products")]
        public IEnumerable<BidModel> GetHighestBids(IEnumerable<SimpleProductModel> products)
        {
            var list = _bidService.GetHighestBids(products);
            
            return list == null ? null : list.Select(p => new BidModel(p));
        }
    }
}