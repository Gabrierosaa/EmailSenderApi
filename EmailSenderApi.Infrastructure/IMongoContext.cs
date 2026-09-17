using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

using EmailSenderApi.Domain.Entities;

namespace EmailSenderApi.Infrastructure
{
    public interface IMongoContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }

    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration configuration)
        {
            ConfigureMappings();

            var connectionString = configuration["MongoSettings:ConnectionString"];
            var databaseName = configuration["MongoSettings:DatabaseName"];

            var client = new MongoClient(connectionString);

            _database = client.GetDatabase(databaseName);
        }

        private static void ConfigureMappings()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Profile)))
            {
                BsonClassMap.RegisterClassMap<Profile>(cm =>
                {
                    cm.AutoMap();

                    cm.MapIdMember(x => x.Id)
                        .SetSerializer(
                            new GuidSerializer(GuidRepresentation.Standard)
                        );
                });
            }
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}