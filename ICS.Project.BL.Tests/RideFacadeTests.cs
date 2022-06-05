using ICS.Project.BL.Facades;
using ICS.Project.BL.Models;
using ICS.Project.DAL.Tests.Common;
using ICS.Project.DAL.Tests.Common.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.Project.BL.Tests
{
    public class RideFacadeTests : CRUDFacadeTestsBase
    {
        private readonly RideFacade _rideFacadeSUT;

        public RideFacadeTests(ITestOutputHelper output) : base(output)
        {
            _rideFacadeSUT = new RideFacade(UnitOfWorkFactory, Mapper);
        }

        [Fact]
        public async Task Create_WithNonExistingItem_DoesNotThrow()
        {
            // Arrange
            var model = new RideModel
            (
                "example city",
                "example location",
                "example destination",
                new DateTime(2015, 3, 2, 14, 0, 0),
                new DateTime(2015, 3, 2, 16, 30, 0),
                default!,
                default!
            );

            // Act
            var _ = await _rideFacadeSUT.SaveAsync(model);
        }

        [Fact]
        public async Task GetAll_Single_CarEntity()
        {
            // Act
            var rides = await _rideFacadeSUT.GetAsync();
            var ride = rides.Single(i => i.Id == RideSeeds.RideEntity.Id);
            
            // Assert
            DeepAssert.Equal(Mapper.Map<RideListModel>(RideSeeds.RideEntity), ride);
        }

        [Fact]
        public async Task GetById_RideEntity()
        {
            // Act
            var ride = await _rideFacadeSUT.GetAsync(RideSeeds.RideEntity.Id);
            
            // Assert
            DeepAssert.Equal(Mapper.Map<RideModel>(RideSeeds.RideEntity), ride);
        }

        [Fact]
        public async Task GetByRideId_NotExist()
        {
            // Act
            var ride = await _rideFacadeSUT.GetAsync(RideSeeds.EmptyRideEntity.Id);
            
            // Assert
            Assert.Null(ride);
        }

        [Fact]
        public async Task EntityRide_DeleteById()
        {
            // Act
            await _rideFacadeSUT.DeleteAsync(RideSeeds.RideEntity.Id);
            await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
            
            // Assert
            Assert.False(await dbxAssert.Rides.AnyAsync(i => i.Id == RideSeeds.RideEntity.Id));
        }

        [Fact]
        public async Task NewRide_InsertOrUpdate_Added()
        {
            // Arrange
            var ride = new RideModel
            (
                "2 example city",
                "2 example location",
                "2 example destination",
                new DateTime(2000, 1, 1, 10, 15, 0),
                new DateTime(2000, 1, 1, 13, 30, 0),
                default!,
                default!
            );

            // Act
            ride = await _rideFacadeSUT.SaveAsync(ride);

            // Assert
            await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
            var rideDb = await dbxAssert.Rides.SingleAsync(i => i.Id == ride.Id);
            DeepAssert.Equal(ride, Mapper.Map<RideModel>(rideDb));
        }

        [Fact]
        public async Task EntityRide_InsertOrUpdate_Updated()
        {
            // Arrange
            var ride = new RideModel
            (
                RideSeeds.RideEntity.ArrivalCity,
                RideSeeds.RideEntity.ArrivalLocation,
                RideSeeds.RideEntity.Destination,
                RideSeeds.RideEntity.ArrivalTime,
                RideSeeds.RideEntity.DestinationTime,
                default!,
                default!
            ) {Id = RideSeeds.RideEntity.Id};

            // Act
            ride.ArrivalCity += "updated";
            ride.ArrivalLocation += "updated";
            await _rideFacadeSUT.SaveAsync(ride);
            
            // Assert
            await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
            var rideDb = await dbxAssert.Rides.SingleAsync(i => i.Id == ride.Id);
            DeepAssert.Equal(ride, Mapper.Map<RideModel>(rideDb));
        }
    }
}