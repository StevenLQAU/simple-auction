using Auction.Common.Data.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Common.Data.MongoDB
{
    public interface IRepositoryBase<T> where T: EntityBase
    {
        Task Create(T entity);
        Task Delete(string id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task Update(T entitiy);
        IMongoDatabase Db { get; }
    }
}
