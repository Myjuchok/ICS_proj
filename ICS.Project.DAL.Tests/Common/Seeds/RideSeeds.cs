using Microsoft.EntityFrameworkCore;
using ICS.Project.DAL.Entities;
using ICS.Project.BL.Models;

namespace ICS.Project.DAL.Tests.Common.Seeds;

public static class RideSeeds
{
    public static readonly RideEntity EmptyRideEntity = new(
        ArrivalCity: default!,
        ArrivalLocation: default!,
        Destination: default!,
        ArrivalTime: default,
        DestinationTime: default,
        DriverId: default!,
        CarId: default!);

    public static readonly RideEntity RideEntity = new(
        ArrivalCity: "Brno",
        ArrivalLocation: "Main Station",
        Destination: "Prague",
        ArrivalTime: new DateTime(2022, 3, 6),
        DestinationTime: new DateTime(2022, 3, 6),
        DriverId: UserSeeds.UserEntity1.Id,
        CarId: CarSeeds.CarEntity.Id
    );

    public static readonly RideEntity RideEntityUpdate = RideEntity with
    {
        Id = Guid.Parse("{4C310197-B613-4B07-B222-B62B3179267B}")
    };

    public static readonly RideEntity RideEntityDelete = RideEntity with
    {
        Id = Guid.Parse("{F1CC2E9B-2D69-47DB-817A-1B94C6BB2B68}")
    };

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RideEntity>().HasData(
            RideEntity,
            RideEntityUpdate,
            RideEntityDelete);
    }
}
