using Auction.Bid.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Bid.Api.Controllers.ViewModels
{
    public class BidModel
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset BidTime { get; set; }

        public BidModel()
        {

        }

        public BidModel(BidEntity entity)
        {
            UserId = entity.UserId;
            ProductId = entity.ProductId;
            Amount = entity.Amount;
            BidTime = entity.CreateTime;
        }
    }
}
