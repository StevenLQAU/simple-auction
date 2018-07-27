using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Common.Models.Products
{
    public class SimpleProductModel
    {
        public string Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset CloseTime { get; set; }
    }
}
