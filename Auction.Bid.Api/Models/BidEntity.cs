using Auction.Bid.Api.Controllers.ViewModels;
using Auction.Common.Data.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Bid.Api.Models
{
    public class BidEntity : EntityBase
    {
        public string ProductId { get; set; }
        public string UserId { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public decimal Amount { get; set; }
        public DateTimeOffset CreateTime { get; set; }

        public static BidEntity Create(BidModel model)
        {
            return new BidEntity
            {
                ProductId = model.ProductId,
                Amount = model.Amount,
                UserId = model.UserId,
                CreateTime = DateTimeOffset.Now
            };
        }
    }
}
