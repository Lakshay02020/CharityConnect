using charity.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace charity.NGOService
{
    public class NGOService
    {
        private readonly IMongoCollection<NGO> _ngoCollection;

        public NGOService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _ngoCollection = database.GetCollection<NGO>(mongoDBSettings.Value.NgoCollectionName);
        }

        public async Task<List<NGO>> GetNGOsAsync()
        {
            return await _ngoCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddNGOAsync(NGO ngo)
        {
            await _ngoCollection.InsertOneAsync(ngo);
        }
    }
}
