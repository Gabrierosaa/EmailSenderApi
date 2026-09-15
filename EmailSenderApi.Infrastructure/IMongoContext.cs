using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

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
            var connectionString = configuration["MongoSettings:ConnectionString"];
            var databaseName = configuration["MongoSettings:DatabaseName"];

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        => _database.GetCollection<T>(name);
    }
}
