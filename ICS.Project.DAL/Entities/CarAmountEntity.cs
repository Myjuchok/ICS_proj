using System;
using System.Collections.Generic;
using ICS.Project.DAL.Entities.Base;
using ICS.Project.DAL.Entities;

namespace ICS.Project.DAL.Entities
{
    public record CarAmountEntity(
        Guid Id,
        Guid OwnerId,
        Guid CarId) : EntityBase
    {
#nullable disable
        public CarAmountEntity() : this(default, default, default) { }
#nullable enable
        public UserEntity? Owner { get; init; }
        public CarEntity? Car { get; init; }
    }
}
