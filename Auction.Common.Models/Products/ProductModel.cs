using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Common.Models.Products
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset CloseTime { get; set; }
        public ProductStatus Status { get; set; }

        public ProductModel() { }
    }
}
