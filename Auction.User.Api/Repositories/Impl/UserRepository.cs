using Auction.Common.Data;
using Auction.Common.Data.MongoDB.Impl;
using Auction.User.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Linq;
using Auction.User.Api.Controllers.ViewModels;

namespace Auction.User.Api.Repositories.Impl
{
    public class UserRepository: RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(IOptions<MongoSetting> settings) : base(settings, "users")
        {

        }

        public async Task CreateSample()
        {
            await Collection.InsertOneAsync(new UserEntity("bloodborn", "abcdef"));
            await Collection.InsertOneAsync(new UserEntity("monsterhunter", "123456"));
            await Collection.InsertOneAsync(new UserEntity("zelda", "111111"));
        }

        public async Task<UserEntity> GetUser(LoginModel model)
        {
            return await Collection.Find(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefaultAsync();
        }
    }
}
