using System;
using System.Collections.Generic;
using ICS.Project.DAL.Entities.Types;
using ICS.Project.DAL.Entities.Base;

namespace ICS.Project.DAL.Entities
{
    public record CarEntity(
        CarTypes Type,
        string Model,
        string Manufacturer,
        DateTime DateOfRegistration,
        int NumberOfSeats,
        string? ImageUrl,
        Guid OwnerId) : EntityBase
    {
        public ICollection<RideEntity> Rides { get; init; } = new List<RideEntity>();
    }
}