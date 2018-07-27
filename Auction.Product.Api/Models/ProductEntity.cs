using Auction.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Product.Api.Models
{
    public class ProductEntity: EntityBase
    {
        public string Name { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset CloseTime { get; set; }
        public ProductStatus Status { get; set; }
    }
}
