using ICS.Project.BL.Models;
using Microsoft.EntityFrameworkCore;
using ICS.Project.DAL.Entities.Types;
using ICS.Project.DAL.Entities;
using ICS.Project.DAL.EntitiesSeeds;

namespace ICS.Project.DAL.Tests.Common.Seeds;

public static class CarSeeds
{
    public static readonly CarEntity CarEntity = new(
        Type: CarTypes.Coupe,
        Model: "Car 1 model",
        Manufacturer: "Car 1 manufacturer",
        DateOfRegistration: new DateTime(2015, 3, 14),
        NumberOfSeats: 3,
        ImageUrl: default,
        OwnerId: UserSeeds.UserEntity1.Id);

    public static readonly CarEntity CarEntityWithNoRides = CarEntity with
    {
        Id = Guid.Parse("{E67B690D-8264-4D06-9CAE-FABAEC36D578}"), 
        Rides = Array.Empty<RideEntity>()
    };

    public static readonly CarEntity CarEntityUpdate = CarEntity with
    {
        Id = Guid.Parse("{57E80E6A-FEDC-450C-8788-F331B89843C1}"),
        Rides = Array.Empty<RideEntity>()
    };

    public static readonly CarEntity CarEntityDelete = CarEntity with
    {
        Id = Guid.Parse("{C551A519-A3C6-4086-BE90-5342E5819BB8}"),
        Rides = Array.Empty<RideEntity>()
    };

    static CarSeeds()
    {
        CarEntity.Rides.Add(RideEntitySeed.Ride1);
    }

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarEntity>().HasData(
            CarEntity with { Rides = Array.Empty<RideEntity>() },
            CarEntityWithNoRides,
            CarEntityUpdate, 
            CarEntityDelete);
    }
}