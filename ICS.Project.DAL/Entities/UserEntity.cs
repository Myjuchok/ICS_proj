using System;
using System.Collections.Generic;
using ICS.Project.DAL.Entities.Base;
using ICS.Project.DAL.Entities.Types;


namespace ICS.Project.DAL.Entities
{
    public record UserEntity(
        UserTypes UserType,
        string Name,
        string Surname,
        DateTime DateOfBirth,
        string? ImageUrl) : EntityBase
    {
        public ICollection<CarEntity> Cars { get; init; } = new List<CarEntity>();
        public ICollection<RideEntity> Rides { get; init; } = new List<RideEntity>();
        public ICollection<RideEntity> Drives { get; init; } = new List<RideEntity>();
    }
}