using System;
using ICS.Project.DAL.Entities;
using ICS.Project.DAL.Entities.Types;
using Microsoft.EntityFrameworkCore;

namespace ICS.Project.DAL.EntitiesSeeds;

public static class UserEntitySeed
{
	public static readonly UserEntity User1 = new (
		UserType: UserTypes.Driver,
		Name: "Cedric",
        Surname: "Diggory",
        DateOfBirth: new DateTime(1986, 5, 13),
		ImageUrl: @"https://static.wikia.nocookie.net/harrypotterfanczech/images/2/25/Edric_Diggory.png/revision/latest?cb=20180827130153"	
	);

	public static readonly UserEntity User2 = new (
		UserType: UserTypes.Passenger,
		Name: "Ronald",
        Surname: "Weasley",
        DateOfBirth: new DateTime(1986, 5, 13),
		ImageUrl: @"https://upload.wikimedia.org/wikipedia/ru/3/32/Grint-Weasley.png"	
	);

	public static readonly UserEntity User3 = new (
		UserType: UserTypes.Passenger,
		Name: "Harry",
        Surname: "Potter",
        DateOfBirth: new DateTime(1988, 8, 24),
		ImageUrl: @"https://wikiimg.tojsiabtv.com/wikipedia/en/d/d7/Harry_Potter_character_poster.jpg"	
	);

	public static void Seed(this ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<UserEntity>().HasData(
			User1,
			User2,
			User3
		); 
	}
}
