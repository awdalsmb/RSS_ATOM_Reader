using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using rss_atom_reader_server.Models;

namespace rss_atom_reader_server.Services
{
    public class DbService
    {
        private IMongoCollection<Feeder> FeederCollection { get; }

        public DbService(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);

            FeederCollection = mongoDatabase.GetCollection<Feeder>(collectionName);
        }

        public async Task<List<Feeder>> GetAllFeeds()
        {
            var feeds = new List<Feeder>();

            var allDocuments = await FeederCollection.FindAsync(new BsonDocument);
            await allDocuments.ForEachAsync(doc => feeds.Add(doc));

            return feeds;

        }
    }
}
