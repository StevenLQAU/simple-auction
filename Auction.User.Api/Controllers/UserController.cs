using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.User.Api.Controllers.ViewModels;
using Auction.User.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet]
        //[Route("AddSample")]
        //[AllowAnonymous]
        //public IActionResult AddSample()
        //{
        //    _userService.AddSampleUser();
        //    return Ok();
        //}

        [HttpPost]
        [Route("Login")]
        public async Task<string> ValidateUser(LoginModel model)
        {
            var user = await _userService.GetUser(model);
            return user?.Id.ToString();
        }
    }
}