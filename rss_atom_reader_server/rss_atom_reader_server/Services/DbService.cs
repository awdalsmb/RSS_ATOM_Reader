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
        private IMongoCollection<NewsFeed> FeederCollection { get; }

        public DbService(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);

            FeederCollection = mongoDatabase.GetCollection<NewsFeed>(collectionName);
        }

        public async Task<List<NewsFeed>> GetAllFeeds()
        {
            var feeds = new List<NewsFeed>();

            var allDocuments = await FeederCollection.FindAsync(new BsonDocument());
            await allDocuments.ForEachAsync(doc => feeds.Add(doc));

            return feeds;

        }

    }
}
