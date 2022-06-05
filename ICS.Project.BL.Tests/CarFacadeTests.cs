using ICS.Project.BL.Models;
using ICS.Project.BL.Facades;
using ICS.Project.DAL.Entities.Types;
using ICS.Project.DAL.Tests.Common;
using ICS.Project.DAL.Tests.Common.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ICS.Project.BL.Tests
{
    public sealed class CarFacadeTests : CRUDFacadeTestsBase
    {
        private readonly CarFacade _carFacadeSUT;

        public CarFacadeTests(ITestOutputHelper output) : base(output)
        {
            _carFacadeSUT = new CarFacade(UnitOfWorkFactory, Mapper);
        }

        [Fact]
        public async Task Create_WithNonExistingItem_DoesNotThrow()
        {
            // Arrange
            var model = new CarModel
            (
                CarTypes.None,
                "example model 1",
                "example manufacturer 1",
                new DateTime(2002, 05, 25),
                4,
                default!,
                default!
            );

            // Act
            var _ = await _carFacadeSUT.SaveAsync(model);

            // Assert
            Assert.DoesNotThrowAsync(async () => await _carFacadeSUT.SaveAsync(model));
        }

        [Fact]
        public async Task GetAll_Single_CarEntity()
        {
            // Act
            var cars = await _carFacadeSUT.GetAsync();
            var car = cars.Single(i => i.Id == CarSeeds.CarEntity.Id);
            
            // Assert
            DeepAssert.Equal(Mapper.Map<CarListModel>(CarSeeds.CarEntity), car);
        }

        [Fact]
        public async Task GetById_CarEntity()
        {
            // Act
            var car = await _carFacadeSUT.GetAsync(CarSeeds.CarEntity.Id);
            
            // Assert
            DeepAssert.Equal(Mapper.Map<CarModel>(CarSeeds.CarEntity), car);
        }

        [Fact]
        public async Task GetByCarId_NotExist()
        {
            // Act
            Guid emptyCarId = Guid.Parse(input: "{00000000-0000-0000-0000-000000000000}");
            var car = await _carFacadeSUT.GetAsync(emptyCarId);
            
            // Assert
            Assert.Null(car);
        }

        [Fact]
        public async Task EntityCar_DeleteById()
        {
            // Act
            await _carFacadeSUT.DeleteAsync(CarSeeds.CarEntity.Id);
            await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
            
            // Assert
            Assert.False(await dbxAssert.Cars.AnyAsync(i => i.Id == CarSeeds.CarEntity.Id));
        }

        [Fact]
        public async Task NewCar_InsertOrUpdate_Added()
        {
            // Arrange
            var car = new CarModel
            (
                CarTypes.Hatchback,
                "example model 2",
                "example manufacturer 2",
                new DateTime(2020, 01, 23),
                4,
                default!,
                default!
            );

            // Act
            car = await _carFacadeSUT.SaveAsync(car);
            await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();

            // Assert
            var carDb = await dbxAssert.Cars.SingleAsync(i => i.Id == car.Id);
            DeepAssert.Equal(car, Mapper.Map<CarModel>(carDb));
        }
    }
}