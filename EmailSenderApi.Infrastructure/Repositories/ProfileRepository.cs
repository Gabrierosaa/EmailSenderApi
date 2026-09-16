using MongoDB.Driver;
using EmailSenderApi.Domain.Entities;
using EmailSenderApi.Domain.Interfaces;
using EmailSenderApi.Infrastructure;

namespace EmailSenderApi.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IMongoCollection<Profile> _collection;

        public ProfileRepository(IMongoContext context)
        {
            _collection = context.GetCollection<Profile>("Profiles");
        }

        public async Task CreateAsync(Profile profile)
        {
            await _collection.InsertOneAsync(profile); 
        }

        public async Task<Profile> GetAsyncById(Guid id)
        {
            var filter = Builders<Profile>.Filter.Eq(p => p.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Profile> GetAsync(Profile profiles)
        {
            var builder = Builders<Profile>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrWhiteSpace(profiles.Name))
                filter &= builder.Eq(p => p.Name, profiles.Name);

            if (!string.IsNullOrWhiteSpace(profiles.Email))
                filter &= builder.Eq(p => p.Email, profiles.Email);

            if (!string.IsNullOrWhiteSpace(profiles.Description))
                filter &= builder.Eq(p => p.Description, profiles.Description);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
