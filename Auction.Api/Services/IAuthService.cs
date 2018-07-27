
using Auction.Common.Models;
using Auction.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.Services
{
    public interface IAuthService
    {
        Task<JwtUserModel> Auth(LoginModel tokenRequest);
    }
}
