using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Common.Models.Bids
{
    public class BidModel
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset BidTime { get; set; }
    }
}
