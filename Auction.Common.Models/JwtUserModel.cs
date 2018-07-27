using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Common.Models
{
    public class JwtUserModel
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset ExpireAt { get; set; }
    }
}
