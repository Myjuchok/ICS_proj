using ICS.Project.BL.Models;
using System.Linq;
using System.Threading.Tasks;
using ICS.Project.BL.Facades;
using ICS.Project.DAL.Tests.Common;
using ICS.Project.DAL.Entities.Types;
using ICS.Project.DAL.Tests.Common.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.Project.BL.Tests
{
    public sealed class UserFacadeTests : CRUDFacadeTestsBase
    {
        private readonly UserFacade _userFacadeSUT;

        public UserFacadeTests(ITestOutputHelper output) : base(output)
        {
            _userFacadeSUT = new UserFacade(UnitOfWorkFactory, Mapper);
        }

        [Fact]
        public async Task Create_WithNonExistingItem_DoesNotThrow()
        {
            // Act
            var model = new UserModel
            (
                UserType: UserTypes.Driver,
                Name: @"Name 1",
                Surname: @"Surname 1",
                DateOfBirth: DateTime.Today
            );

            var _ = await _userFacadeSUT.SaveAsync(model);
        }

        [Fact]
        public async Task GetAll_Single_UserEntity1()
        {
            // Act
            var users = await _userFacadeSUT.GetAsync();
            var user = users.Single(i => i.Id == UserSeeds.UserEntity1.Id);
            
            // Assert
            DeepAssert.Equal(Mapper.Map<UserListModel>(UserSeeds.UserEntity1), user);
        }

        [Fact]
        public async Task GetById_UserEntity1()
        {
            // Act
            var user = await _userFacadeSUT.GetAsync(UserSeeds.UserEntity1.Id);
            
            // Assert
            DeepAssert.Equal(Mapper.Map<UserModel>(UserSeeds.UserEntity1), user);
        }

        [Fact]
        public async Task GetById_NonExistent()
        {
            // Act
            var user = await _userFacadeSUT.GetAsync(UserSeeds.EmptyUserEntity.Id);
            
            // Assert
            Assert.Null(user);
        }

        [Fact]
        public async Task UserEntity1_DeleteById()
        {
            // Act
            await _userFacadeSUT.DeleteAsync(UserSeeds.UserEntity1.Id);
            await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
            
            // Assert
            Assert.False(await dbxAssert.Users.AnyAsync(i => i.Id == UserSeeds.UserEntity1.Id));
        }


        [Fact]
        public async Task NewUser_InsertOrUpdate_Added()
        {
            // Arrange
            var user = new UserModel
            (
                UserType: UserTypes.Passenger,
                Name: @"Name 2",
                Surname: @"Surname 2",
                DateOfBirth: DateTime.Today
            );

            // Act
            user = await _userFacadeSUT.SaveAsync(user);

            // Assert
            await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
            var userFromDb = await dbxAssert.Users.SingleAsync(i => i.Id == user.Id);
            DeepAssert.Equal(user, Mapper.Map<UserModel>(userFromDb));
        }

        [Fact]
        public async Task UserEntity1_InsertOrUpdate_UserUpdated()
        {
            // Arrange
            var user = new UserModel
            (
                UserSeeds.UserEntity1.UserType,
                UserSeeds.UserEntity1.Name,
                UserSeeds.UserEntity1.Surname,
                UserSeeds.UserEntity1.DateOfBirth            
            ) { Id = UserSeeds.UserEntity1.Id };

            // Act
            user.UserType = UserTypes.Passenger;
            user.Name += "updated";
            user.Surname += "updated";
            await _userFacadeSUT.SaveAsync(user);

            // Assert
            await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
            var userFromDb = await dbxAssert.Users.SingleAsync(i => i.Id == user.Id);
            DeepAssert.Equal(user, Mapper.Map<UserModel>(userFromDb));
        }
    }
}