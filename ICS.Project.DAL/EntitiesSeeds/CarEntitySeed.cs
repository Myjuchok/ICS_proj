using System;
using ICS.Project.DAL.Entities;
using ICS.Project.DAL.Entities.Types;
using Microsoft.EntityFrameworkCore;

namespace ICS.Project.DAL.EntitiesSeeds;

public static class CarEntitySeed
{
    public static readonly CarEntity Car1 = new(
		Type: CarTypes.Coupe,
		Model: "BEETLE",
		Manufacturer: "VOLKSWAGEN",
		DateOfRegistration: new DateTime(2015, 3, 14),
	    NumberOfSeats: 3,
		ImageUrl: @"https://static1.hotcarsimages.com/wordpress/wp-content/uploads/2019/10/VOLKSWAGEN-BEETLE.jpg?q=50&fit=crop&w=943&dpr=1.5",
		OwnerId: UserEntitySeed.User1.Id
	);


	public static void Seed(this ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CarEntity>().HasData( Car1 ); 
	}
}