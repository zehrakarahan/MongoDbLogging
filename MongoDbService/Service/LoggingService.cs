using DnsClient;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MongoDbService.Service
{
    public class LoggingService
    {
        private readonly IMongoCollection<Loggings> _loggingCollection;

        public LoggingService(
            IOptions<LoggingStoreDatabaseSettings> loggingsStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                loggingsStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                loggingsStoreDatabaseSettings.Value.DatabaseName);

            _loggingCollection = mongoDatabase.GetCollection<Loggings>(
                loggingsStoreDatabaseSettings.Value.LoggingCollectionName);
        }

        public async Task<List<Loggings>> GetAsync() =>
            await _loggingCollection.Find(_ => true).ToListAsync();

        public async Task<Loggings?> GetAsync(string id) =>
            await _loggingCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Loggings newBook) =>

            await _loggingCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Loggings updatedBook) =>
            await _loggingCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _loggingCollection.DeleteOneAsync(x => x.Id == id);
    }
}
