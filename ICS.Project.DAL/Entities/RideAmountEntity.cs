using System;
using System.Collections.Generic;
using ICS.Project.DAL.Entities;
using ICS.Project.DAL.Entities.Base;

namespace ICS.Project.DAL.Entities
{
    public record RideAmountEntity(
        Guid Id,
        Guid RideId,
        Guid PassengerId) : EntityBase
    {
#nullable disable
        public RideAmountEntity() : this(default, default, default) { }
#nullable enable
        public UserEntity? Passenger { get; init; }
        public RideEntity? Ride { get; init; }
    }
}