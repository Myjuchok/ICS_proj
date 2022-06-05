using ICS.Project.DAL.Entities;
using AutoMapper;
using ICS.Project.BL.Models.Base;
using System;

namespace ICS.Project.BL.Models
{
    public record RideModel(
        string ArrivalCity,
        string ArrivalLocation,
        string Destination,
        DateTime ArrivalTime,
        DateTime DestinationTime,
        Guid DriverId,
        Guid CarId) : ModelBase
    {
        public string ArrivalCity { get; set; } = ArrivalCity;
        public string ArrivalLocation { get; set; } = ArrivalLocation;
        public string Destination { get; set; } = Destination;
        public DateTime ArrivalTime { get; set; } = ArrivalTime;
        public DateTime DestinationTime { get; set; } = DestinationTime;
        public Guid DriverId { get; set; } = DriverId;
        public Guid CarId { get; set; } = CarId;

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<RideEntity, RideModel>().ReverseMap();
            }
        }

        public static RideModel Empty => new(default!, string.Empty, string.Empty, default!, default, default!, default!);
    }
}
