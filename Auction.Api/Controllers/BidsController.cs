using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Api.ExternalServices;
using Auction.Api.Services;
using Auction.Common.Models.Bids;
using Auction.Common.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        private readonly IBidsService _bidsService;

        public BidsController(IBidsService bidsService)
        {
            _bidsService = bidsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<BidModel> CreateBid(BidModel model)
        {
            var userId = HttpContext.User?.Identity.Name;
            if(userId == null)
            {
                return null;
            }
            model.UserId = userId;
            return await _bidsService.CreateBid(model);
        }

        [HttpGet]
        [Route("Products")]
        public async Task<IEnumerable<ProductBidModel>> GetProducts()
        {
            return await _bidsService.GetProducts();
        }
    }
}