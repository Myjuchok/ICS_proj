using ICS.Project.BL.Models;
using Microsoft.EntityFrameworkCore;
using ICS.Project.DAL.Entities.Types;
using ICS.Project.DAL.Entities;
using ICS.Project.DAL.EntitiesSeeds;

namespace ICS.Project.DAL.Tests.Common.Seeds;

public static class UserSeeds
{
    public static readonly UserEntity EmptyUserEntity = new(
        UserType: default,
        Name: default!,
        Surname: default!,
        DateOfBirth: default,
        ImageUrl: default);

    public static readonly UserEntity UserEntity1 = new(
        UserType: UserTypes.Driver,
        Name: "User",
        Surname: "Two",
        DateOfBirth: new DateTime(1986, 5, 13),
        ImageUrl: default);

    public static readonly UserEntity UserEntity2 = new(
        UserType: UserTypes.Passenger,
        Name: "User",
        Surname: "One",
        DateOfBirth: new DateTime(1986, 5, 13),
        ImageUrl: default);

    public static readonly UserEntity UserEntityWithNoCars = UserEntity1 with
    {
        Id = Guid.Parse("{14133FB6-978A-444C-B71D-DED7EB815B70}"),
        Cars = Array.Empty<CarEntity>()
    };

    public static readonly UserEntity UserEntityWithNoRides = UserEntity1 with
    {
        Id = Guid.Parse("{33EFE92F-E8CF-41CD-B88E-E7FACB201822}"),
        Rides = Array.Empty<RideEntity>()
    };

    public static readonly UserEntity UserEntityWithNoDrives = UserEntity1 with
    {
        Id = Guid.Parse("{6D7536E4-6239-499A-B15D-332B27F19D9D}"),
        Drives = Array.Empty<RideEntity>()
    };

    public static readonly UserEntity UserEntityUpdate = UserEntity1 with
    {
        Id = Guid.Parse("{B76BB7B8-FA2E-4A16-9E0B-A48614EC7C16}"),
        Cars = Array.Empty<CarEntity>(),
        Rides = Array.Empty<RideEntity>(),
        Drives = Array.Empty<RideEntity>()
    };

    public static readonly UserEntity UserEntityDelete = UserEntity1 with
    {
        Id = Guid.Parse("{6D855BE4-6110-4DCD-AE8A-60B39B75C52D}"),
        Cars = Array.Empty<CarEntity>(),
        Rides = Array.Empty<RideEntity>(),
        Drives = Array.Empty<RideEntity>()
    };

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasData(
            UserEntity1 with { Cars = Array.Empty<CarEntity>(), Rides = Array.Empty<RideEntity>(), Drives = Array.Empty<RideEntity>()},
            UserEntityWithNoCars,
            UserEntityWithNoRides,
            UserEntityWithNoDrives,
            UserEntityUpdate,
            UserEntityDelete);
    }
}