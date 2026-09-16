using EmailSenderApi.Domain.Entities;
using EmailSenderApi.Domain.Interfaces;
using EmailSenderApi.Infrastructure;
using MongoDB.Driver;

namespace EmailSenderApi.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IMongoCollection<Email> _collection;

        public EmailRepository(IMongoContext context)
        {
            _collection = context.GetCollection<Email>("Emails");
        }

        public async Task CreateAsync(Email dto)
        {
            await _collection.InsertOneAsync(dto);
        }
    }
}
