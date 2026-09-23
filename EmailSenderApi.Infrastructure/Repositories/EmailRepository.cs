using EmailSenderApi.Domain.Interfaces;
using EmailSenderApi.Infrastructure;
using MongoDB.Driver;

namespace EmailSenderApi.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IMongoCollection<EmailSenderApi.Domain.Entities.Email> _collection;

        public EmailRepository(IMongoContext context)
        {
            _collection = context.GetCollection<EmailSenderApi.Domain.Entities.Email>("Emails");
        }

        public async Task CreateAsync(EmailSenderApi.Domain.Entities.Email dto)
        {
            await _collection.InsertOneAsync(dto);
        }
    }
}
