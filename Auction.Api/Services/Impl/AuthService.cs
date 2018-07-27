
using Auction.Api.ExternalServices;
using Auction.Api.Jwt;
using Auction.Common.Models;
using Auction.Common.Models.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Api.Services.Impl
{
    public class AuthService: IAuthService
    {
        private readonly IOptions<JwtOptions> _settings;
        private readonly IExternalService _externalService;

        public AuthService(IOptions<JwtOptions> settings, IExternalService externalService)
        {
            _settings = settings;
            _externalService = externalService;
        }

        public async Task<JwtUserModel> Auth(LoginModel model)
        {
            var userId = await _externalService.ValidateUser(model);
            if (userId != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, userId)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Value.Key));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                DateTime expireAt = _settings.Value.Expires;

                var token = new JwtSecurityToken(
                    issuer: _settings.Value.Issuer,
                    audience: _settings.Value.Audience,
                    claims: claims,
                    expires: expireAt,
                    notBefore: _settings.Value.NotBefore,
                    signingCredentials: creds);

                return new JwtUserModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    UserId = userId,
                    ExpireAt = expireAt
                };
            }

            return null;
        }

    }
}
