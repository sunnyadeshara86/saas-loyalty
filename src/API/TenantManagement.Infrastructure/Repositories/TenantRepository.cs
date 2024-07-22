using MongoDB.Bson;
using MongoDB.Driver;
using TenantManagement.Domain.Entities;
using TenantManagement.Domain.Interfaces;

namespace TenantManagement.Infrastructure.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly IMongoCollection<Tenant> _tenants;
        private readonly IMongoCollection<BsonDocument> _locks;

        public TenantRepository(IMongoDatabase database)
        {
            _tenants = database.GetCollection<Tenant>("Tenants");
            _locks = database.GetCollection<BsonDocument>("locks");
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            var result = await _tenants.FindAsync(Builders<Tenant>.Filter.Empty);
            return await result.ToListAsync();
        }

        public async Task<Tenant> GetByIdAsync(ObjectId id)
        {
            var filter = Builders<Tenant>.Filter.Eq(t => t.Id, id);

            var result = await _tenants.FindAsync(filter);

            return result.FirstOrDefault();
        }

        public async Task<Tenant> GetByNameAsync(string name)
        {
            var filter = Builders<Tenant>.Filter.Eq(t => t.Name, name);

            var result = await _tenants.FindAsync(filter);

            return result.FirstOrDefault();
        }

        public async Task<ObjectId> CreateAsync(Tenant tenant)
        {
            await _tenants.InsertOneAsync(tenant);
            return tenant.Id;
        }

        public async Task<bool> UpdateAsync(Tenant tenant)
        {
            var lockKey = tenant.Id.ToString();
            var lockAcquired = await TryAcquireLockAsync(lockKey);
            if (!lockAcquired)
            {
                return false;
            }

            try
            {
                var filter = Builders<Tenant>.Filter.Eq(t => t.Id, tenant.Id);
                await _tenants.ReplaceOneAsync(filter, tenant, new ReplaceOptions { IsUpsert = true });
                return true;
            }
            finally
            {
                await ReleaseLockAsync(lockKey);
            }
        }

        public async Task DeleteAsync(ObjectId id)
        {
            await _tenants.DeleteOneAsync(t => t.Id == id);
        }

        private async Task<bool> TryAcquireLockAsync(string lockKey)
        {
            try
            {
                await _locks.InsertOneAsync(new BsonDocument { { "_id", lockKey } });
                return true;
            }
            catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
                return false;
            }
        }

        private Task ReleaseLockAsync(string lockKey)
        {
            return _locks.DeleteOneAsync(new BsonDocument { { "_id", lockKey } });
        }
    }
}