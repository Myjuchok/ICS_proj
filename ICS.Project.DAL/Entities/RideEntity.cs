using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ICS.Project.DAL.Entities.Base;

namespace ICS.Project.DAL.Entities
{
    public record RideEntity(
        string ArrivalCity, 
        string ArrivalLocation, 
        string Destination, 
        DateTime ArrivalTime, 
        DateTime DestinationTime,
        Guid DriverId,
        Guid CarId) : EntityBase
    {
        [NotMapped]
        public ICollection<UserEntity> Passengers { get; init; } = new List<UserEntity>();
    }   
}
