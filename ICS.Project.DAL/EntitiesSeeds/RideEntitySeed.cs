using System;
using ICS.Project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.Project.DAL.EntitiesSeeds;

public static class RideEntitySeed
{
	public static readonly RideEntity Ride1 = new(
        ArrivalCity: "Brno",
        ArrivalLocation: "Main Station",
        Destination: "Prague",
        ArrivalTime: new DateTime(2022, 3, 6),
        DestinationTime: new DateTime(2022, 3, 6),
        DriverId: UserEntitySeed.User1.Id,
        CarId: CarEntitySeed.Car1.Id
    );

    public static void Seed(this ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<RideEntity>().HasData( Ride1 ); 
	}
}
