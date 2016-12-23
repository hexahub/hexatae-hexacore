using HexaCore.Tickets.Models.Ticket;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace HexaCore.Tickets.Data.Configuration
{
    public class MongoDBConfiguration<TEntity> where TEntity : class
    {
        protected IMongoDatabase _db;
        protected IMongoCollection<TEntity> _entities;
        protected FilterDefinitionBuilder<TEntity> _builder;
        protected string _table;

        protected MongoDBConfiguration(string connection, string table)
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = "mongodb://admin:ero9199@ds046939.mlab.com:46939/hexacore";
            }

            var settings = MongoClientSettings.FromUrl(new MongoUrl(connection));
            var client = new MongoClient(settings);
            _table = table;
            _db = client.GetDatabase("hexacore");
            _entities = _db.GetCollection<TEntity>(_table);
            _builder = Builders<TEntity>.Filter;
        }
    }
}
