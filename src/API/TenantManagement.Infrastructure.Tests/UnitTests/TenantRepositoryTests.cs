using Moq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;
using TenantManagement.Domain.Entities;
using TenantManagement.Domain.Interfaces;
using TenantManagement.Infrastructure.Repositories;
using Xunit;

namespace TenantManagement.Infrastructure.Tests.UnitTests
{
    public class TenantRepositoryTests
    {
        private readonly Mock<IMongoCollection<Tenant>> _mockCollection;
        private readonly Mock<IMongoDatabase> _mockDatabase;
        private readonly TenantRepository _tenantRepository;
        private readonly Mock<IAsyncCursor<Tenant>> _mockCursor;
        private readonly Tenant _testTenant;

        public TenantRepositoryTests()
        {
            _mockCollection = new Mock<IMongoCollection<Tenant>>();
            _mockDatabase = new Mock<IMongoDatabase>();
            _mockCursor = new Mock<IAsyncCursor<Tenant>>();
            _testTenant = new Tenant("Test Tenant", "test@example.com");

            _mockDatabase.Setup(db => db.GetCollection<Tenant>(It.IsAny<string>(), It.IsAny<MongoCollectionSettings>()))
                .Returns(_mockCollection.Object);

            _tenantRepository = new TenantRepository(_mockDatabase.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsTenant_WhenTenantExists()
        {
            // Arrange
            var tenantId = _testTenant.Id;
            var list = new List<Tenant> { _testTenant }; // This list simulates the result set from MongoDB.

            _mockCursor.Setup(_ => _.Current).Returns(list); // Setup the Current property to return our list.
            _mockCursor.SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                       .Returns(true) // First call to MoveNext returns true, indicating there are results.
                       .Returns(false); // Subsequent call returns false, indicating end of results.

            _mockCollection.Setup(op => op.FindAsync(
                It.IsAny<FilterDefinition<Tenant>>(), // Use It.IsAny to avoid dealing with FilterDefinition rendering.
                It.IsAny<FindOptions<Tenant, Tenant>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(_mockCursor.Object);

            // Act
            var result = await _tenantRepository.GetByIdAsync(tenantId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(tenantId, result.Id);
        }

        [Fact]
        public async Task CreateAsync_AddsTenantSuccessfully()
        {
            // Arrange
            _mockCollection.Setup(op => op.InsertOneAsync(It.IsAny<Tenant>(), null, default(CancellationToken)))
                .Returns(Task.CompletedTask);

            // Act
            var resultId = await _tenantRepository.CreateAsync(_testTenant);

            // Assert
            Assert.Equal(_testTenant.Id, resultId);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesTenantSuccessfully()
        {
            // Arrange
            _mockCollection.Setup(op => op.ReplaceOneAsync(It.IsAny<FilterDefinition<Tenant>>(),
                                                           It.IsAny<Tenant>(),
                                                           It.IsAny<ReplaceOptions>(),
                                                           default(CancellationToken)))
                .ReturnsAsync(new ReplaceOneResult.Acknowledged(1, 1, _testTenant.Id));

            // Act
            await _tenantRepository.UpdateAsync(_testTenant);

            // Assert
            // Verify that ReplaceOneAsync was called once with the correct tenant
            _mockCollection.Verify(op => op.ReplaceOneAsync(It.IsAny<FilterDefinition<Tenant>>(),
                                                            _testTenant,
                                                            It.IsAny<ReplaceOptions>(),
                                                            default(CancellationToken)), Times.Once);
        }

        public async Task DeleteAsync_DeletesTenantSuccessfully()
        {
            // Arrange
            _mockCollection.Setup(op => op.DeleteOneAsync(It.IsAny<FilterDefinition<Tenant>>(), default(CancellationToken)))
                .ReturnsAsync(new DeleteResult.Acknowledged(1));

            // Act
            await _tenantRepository.DeleteAsync(_testTenant.Id);

            // Assert
            // Verify that DeleteOneAsync was called once with the correct filter
            _mockCollection.Verify(op => op.DeleteOneAsync(It.IsAny<FilterDefinition<Tenant>>(), default(CancellationToken)), Times.Once);
        }
    }
}