using System;
using System.Linq;
using System.Threading.Tasks;
using ICS.Project.DAL.Tests.Common.Factories;
using ICS.Project.DAL.Tests.Common.Seeds;
using ICS.Project.DAL.Entities;
using ICS.Project.DAL.Entities.Types;
using ICS.Project.DAL.EntitiesSeeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using Newtonsoft.Json;

namespace ICS.Project.DAL.Tests
{
    public class DbContextCarTests : DbContextTestBase
    {
        public DbContextCarTests(ITestOutputHelper output) : base(output) {}

        [Fact]
        public async Task AddNew_Car()
        {
            // Arrange

            CarEntity entity = new CarEntity(
                Type: CarTypes.Coupe,
                Model: "Car 1 model",
                Manufacturer: "Car 1 manufacturer",
                DateOfRegistration: new DateTime(2015, 3, 14),
                NumberOfSeats: 3,
                ImageUrl: default,
                OwnerId: UserEntitySeed.User1.Id);

            // Act
            IcsProjectDbContextSUT.Cars.Add(entity);
            await IcsProjectDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await dbContextFactory.CreateDbContextAsync();
            var actualEntities = await dbx.Cars.SingleAsync(i => i.Id == entity.Id);
            Assert.Equal(JsonConvert.SerializeObject(entity), JsonConvert.SerializeObject(actualEntities));
        }

        [Fact]
        public async Task GetAll_Cars_ContainsCarEntity()
        {
            // Act
            var entities = await IcsProjectDbContextSUT.Cars.ToArrayAsync();

            // Assert
            Assert.Contains(JsonConvert.SerializeObject(CarSeeds.CarEntity), JsonConvert.SerializeObject(entities));
        }

        [Fact]
        public async Task GetById_Car_CarEntityRetrieved()
        {
            // Act
            var entity = await IcsProjectDbContextSUT.Cars.SingleAsync(i => i.Id == CarSeeds.CarEntity.Id);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(CarSeeds.CarEntity), JsonConvert.SerializeObject(entity));
        }

        [Fact]
        public async Task Update_Car()
        {
            // Arrange
            var baseEntity = CarSeeds.CarEntityUpdate;
            var entity = baseEntity with
            {
                Model = baseEntity + "Updated",
                Manufacturer = baseEntity + "Updated"
            };

            // Act
            IcsProjectDbContextSUT.Cars.Update(entity);
            await IcsProjectDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await dbContextFactory.CreateDbContextAsync();
            var actualEntity = await dbx.Cars.SingleAsync(i => i.Id == entity.Id);
            Assert.Equal(JsonConvert.SerializeObject(entity), JsonConvert.SerializeObject(actualEntity));
        }

        [Fact]
        public async Task Delete_Car()
        {
            // Arrange
            var entityBase = CarSeeds.CarEntityDelete;

            // Act 
            IcsProjectDbContextSUT.Cars.Remove(entityBase);
            await IcsProjectDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await IcsProjectDbContextSUT.Cars.AnyAsync(i => i.Id == entityBase.Id));
        }

        [Fact]
        public async Task Delete_Car_ById()
        {
            // Arrange
            var entityBase = CarSeeds.CarEntityDelete;

            // Act
            IcsProjectDbContextSUT.Remove(IcsProjectDbContextSUT.Cars.Single(i => i.Id == entityBase.Id));
            await IcsProjectDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await IcsProjectDbContextSUT.Cars.AnyAsync(i => i.Id == entityBase.Id));
        }

        [Fact]
        public async Task Delete_CarWithNoRides_Throws()
        {
            if (dbContextFactory is DbContextTestingInMemoryFactory) return;

            // Arrange
            var entityBase = CarSeeds.CarEntityWithNoRides;

            // Act & Assert
            IcsProjectDbContextSUT.Cars.Remove(entityBase);
            await Assert.ThrowsAsync<DbUpdateException>(async () => await IcsProjectDbContextSUT.SaveChangesAsync());
        }
    }
    
}
