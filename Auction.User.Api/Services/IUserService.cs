
using Auction.User.Api.Controllers.ViewModels;
using Auction.User.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.User.Api.Services
{
    public interface IUserService
    {
        Task<UserEntity> GetUser(LoginModel model);
        Task AddSampleUser();
    }
}
