using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Bid.Api.Controllers.ViewModels
{
    public class SimpleProductModel
    {
        public string Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset CloseTime { get; set; }
    }
}
