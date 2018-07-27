using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Api.Jwt
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public DateTime Expires => DateTime.Now.AddMinutes(20);
        public DateTime NotBefore => DateTime.Now;

        public JwtOptions()
        {

        }
    }
}
