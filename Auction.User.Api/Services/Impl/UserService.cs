
using Auction.User.Api.Controllers.ViewModels;
using Auction.User.Api.Models;
using Auction.User.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.User.Api.Services.Impl
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddSampleUser()
        {
            await _userRepository.CreateSample();
        }

        public async Task<UserEntity> GetUser(LoginModel model)
        {
            return await _userRepository.GetUser(model);
        }
    }
}
