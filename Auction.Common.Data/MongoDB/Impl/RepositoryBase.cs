using Auction.Common.Data.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Common.Data.MongoDB.Impl
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly string _collectionName;
        protected MongoClient _client;
        private readonly IMongoDatabase _db;
        public IMongoDatabase Db => _db;
        protected readonly IMongoCollection<T> _collection;

        public RepositoryBase(IOptions<MongoSetting> settings, string collectionName)
        {
            string connectionString = settings.Value.ConnectionString;
            _client = new MongoClient(connectionString);
            _db = _client.GetDatabase(settings.Value.DatabaseName);
            _collectionName = collectionName;
            _collection = _db.GetCollection<T>(_collectionName);
        }


        public RepositoryBase()
        {
        }

        protected IMongoCollection<T> Collection => _collection;

        public async Task Create(T entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task Delete(string id)
        {
            try
            {
                await _collection.DeleteOneAsync<T>(entity => entity.Id == GetObjectId(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(T entitiy)
        {
            try
            {
                var result = await _collection.ReplaceOneAsync<T>(x => x.Id == entitiy.Id, entitiy);
                if (!result.IsAcknowledged || !(result.ModifiedCount > 0))
                {
                    throw new Exception("Failed to update");
                }
                return;
            }
            catch (Exception)
            {
                // log or manage the exception
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _collection.Find(entity => true).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetById(string id)
        {
            try
            {
                return await _collection.Find<T>(entity => entity.Id == GetObjectId(id)).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private ObjectId GetObjectId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                objectId = ObjectId.Empty;
            }

            return objectId;
        }
    }
}
