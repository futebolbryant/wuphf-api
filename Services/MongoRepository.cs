
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Services
{
    public abstract class MongoRepository<T>
    {
        
        private IMongoClient _client;
        private IMongoDatabase _database;
        public MongoRepository()
        {
            _client = new MongoClient("mongodb://40.84.192.70:27017");
            _database = _client.GetDatabase("wuphf");
        }      
        
        public abstract string GetCollectionName();

        public IMongoCollection<T> GetCollection()
        {
            return _database.GetCollection<T>(GetCollectionName());
        }
        
        public async virtual Task<List<T>> FindAll()
        {
            return await GetCollection().Find(new BsonDocument()).ToListAsync();
        }
        
        public async virtual Task Save(T obj)
        {
            await GetCollection().InsertOneAsync(obj);
        }
        
        public async virtual Task Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await GetCollection().DeleteOneAsync(filter);
        }
    }
}
