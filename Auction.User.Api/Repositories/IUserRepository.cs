using Auction.Common.Data.MongoDB;
using Auction.User.Api.Controllers.ViewModels;
using Auction.User.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.User.Api.Repositories
{
    public interface IUserRepository: IRepositoryBase<UserEntity>
    {
        Task CreateSample();
        Task<UserEntity> GetUser(LoginModel model);
    }
}
