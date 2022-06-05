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
    public class DbContextUserTests : DbContextTestBase
    {
        public DbContextUserTests(ITestOutputHelper output) : base(output) {}

        [Fact]
        public async Task AddNew_User()
        {
            // Arrange

            UserEntity entity = new(
                UserType: UserTypes.Driver,
                Name: "User",
                Surname: "Two",
                DateOfBirth: new DateTime(1986, 5, 13),
                ImageUrl: default);

            // Act
            IcsProjectDbContextSUT.Users.Add(entity);
            await IcsProjectDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await dbContextFactory.CreateDbContextAsync();
            var actualEntities = await dbx.Users.SingleAsync(i => i.Id == entity.Id);
            Assert.Equal(JsonConvert.SerializeObject(entity), JsonConvert.SerializeObject(actualEntities));
        }

        [Fact]
        public async Task GetAllUsers_ContainsUserEntity()
        {
            // Act
            var entities = await IcsProjectDbContextSUT.Users.ToArrayAsync();

            // Assert
            Assert.Contains(JsonConvert.SerializeObject(UserSeeds.UserEntity1), JsonConvert.SerializeObject(entities));
        }

        [Fact]
        public async Task GetByUserId_UserEntity1Retrieved()
        {
            // Act
            var entity = await IcsProjectDbContextSUT.Users.SingleAsync(i => i.Id == UserSeeds.UserEntity1.Id);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(UserSeeds.UserEntity1), JsonConvert.SerializeObject(entity));
        }

        [Fact]
        public async Task Update_User()
        {
            // Arrange
            var baseEntity = UserSeeds.UserEntityUpdate;
            var entity = baseEntity with
            {
                Name = baseEntity + "Updated",
                Surname = baseEntity + "Updated",
            };

            // Act
            IcsProjectDbContextSUT.Users.Update(entity);
            await IcsProjectDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await dbContextFactory.CreateDbContextAsync();
            var actualEntity = await dbx.Users.SingleAsync(i => i.Id == entity.Id);
            Assert.Equal(JsonConvert.SerializeObject(entity), JsonConvert.SerializeObject(actualEntity));
        }

        [Fact]
        public async Task Delete_User()
        {
            // Arrange
            var entityBase = UserSeeds.UserEntityDelete;

            // Act
            IcsProjectDbContextSUT.Users.Remove(entityBase);
            await IcsProjectDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await IcsProjectDbContextSUT.Users.AnyAsync(i => i.Id == entityBase.Id));
        }

        [Fact]
        public async Task Delete_User_ById()
        {
            // Arrange 
            var entityBase = UserSeeds.UserEntityDelete;

            // Act
            IcsProjectDbContextSUT.Remove(IcsProjectDbContextSUT.Users.Single(i => i.Id == entityBase.Id));
            await IcsProjectDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await IcsProjectDbContextSUT.Users.AnyAsync(i => i.Id == entityBase.Id));
        }
    }
}
