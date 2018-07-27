using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.ExternalServices
{
    public class ExternalEndpointOptions
    {
        public string BidApiUrl { get; set; }
        public string ProductApiUrl { get; set; }
        public string UserApiUrl { get; set; }
    }
}
