using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class DbContextRideTests : DbContextTestBase
    {
        public DbContextRideTests(ITestOutputHelper output) : base(output) {}

        [Fact]
        public async Task AddNew_Ride()
        {
            // Arrange

            var arrTimeString = "6/3/2022 08:00:00 PM";
            var depTimeSting = "6/4/2022 00:00:00 AM";

            RideEntity entity = new(
                ArrivalCity: "Brno",
                ArrivalLocation: "Main Station",
                Destination: "Prague",
                ArrivalTime: DateTime.Parse(arrTimeString, System.Globalization.CultureInfo.InvariantCulture),
                DestinationTime: DateTime.Parse(depTimeSting, System.Globalization.CultureInfo.InvariantCulture),
                DriverId: default!, //FIXME
                CarId: default! //FIXME
            );

            // Act
            IcsProjectDbContextSUT.Rides.Add(entity);
            await IcsProjectDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await dbContextFactory.CreateDbContextAsync();
            var actualEntities = await dbx.Rides.SingleAsync(i => i.Id == entity.Id);
            Assert.Equal(JsonConvert.SerializeObject(entity), JsonConvert.SerializeObject(actualEntities));
        }

        [Fact]
        public async Task GetAllRides_Contains_RideEntity()
        {
            // Act
            var entities = await IcsProjectDbContextSUT.Rides.ToArrayAsync();

            // Assert
            Assert.Contains(JsonConvert.SerializeObject(RideSeeds.RideEntity), JsonConvert.SerializeObject(entities));
        }

        [Fact]
        public async Task GetByRideId_RideEntityRetrieved()
        {
            // Act 
            var entity = await IcsProjectDbContextSUT.Rides.SingleAsync(i => i.Id == RideSeeds.RideEntity.Id);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(RideSeeds.RideEntity), JsonConvert.SerializeObject(entity));
        }

        [Fact]
        public async Task Update_Ride()
        {
            // Arrange
            var baseEntity = RideSeeds.RideEntityUpdate;
            var entity = baseEntity with
            {
                ArrivalCity = baseEntity + "Updated",
                ArrivalLocation = baseEntity + "Updated",
                Destination = baseEntity + "Updated",
            };

            // Act
            IcsProjectDbContextSUT.Rides.Update(entity);
            await IcsProjectDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await dbContextFactory.CreateDbContextAsync();
            var actualEntity = await dbx.Rides.SingleAsync(i => i.Id == entity.Id);
            Assert.Equal(JsonConvert.SerializeObject(entity), JsonConvert.SerializeObject(actualEntity));
        }

        [Fact]
        public async Task Delete_Ride()
        {
            // Arrange
            var entityBase = RideSeeds.RideEntityDelete;

            // Act
            IcsProjectDbContextSUT.Rides.Remove(entityBase);
            await IcsProjectDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await IcsProjectDbContextSUT.Rides.AnyAsync(i => i.Id == entityBase.Id));
        }

        [Fact]
        public async Task Delete_Ride_ById()
        {
            // Arrange
            var entityBase = RideSeeds.RideEntityDelete;

            // Act
            IcsProjectDbContextSUT.Remove(IcsProjectDbContextSUT.Rides.Single(i => i.Id == entityBase.Id));
            await IcsProjectDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await IcsProjectDbContextSUT.Rides.AnyAsync(i => i.Id == entityBase.Id));
        }

    }
}
