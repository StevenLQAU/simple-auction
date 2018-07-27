using Auction.Common.Models.Bids;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Common.Models.Products
{
    public class ProductBidModel
    {
        public ProductModel Product { get; set; }
        public BidModel HighestBid { get; set; }
    }
}
