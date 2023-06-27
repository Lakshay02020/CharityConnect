using charity.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace charity.TransactionService
{
    public class TransactionService
    {
        private readonly IMongoCollection<Transaction> _transactionCollection;

        public TransactionService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _transactionCollection = database.GetCollection<Transaction>(mongoDBSettings.Value.TransactionCollectionName);
        }

        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return await _transactionCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _transactionCollection.InsertOneAsync(transaction);
        }
    }
}
