using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Auction.Api.Services;
using Auction.Common.Models;
using Auction.Common.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RequestToken([FromBody] LoginModel request)
        {
            var jwt = await _authService.Auth(request);
            if (jwt == null)
            {
                return Unauthorized();
            }

            return Ok(jwt);
        }
    }
}