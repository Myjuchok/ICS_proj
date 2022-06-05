using AutoMapper;
using ICS.Project.DAL.Entities;
using ICS.Project.BL.Models.Base;
using System;

namespace ICS.Project.BL.Models
{
    public record RideListModel(
        string ArrivalCity,
        string ArrivalLocation,
        string Destination,
        DateTime ArrivalTime,
        DateTime DestinationTime) : ModelBase
    {
        public string ArrivalCity { get; set; } = ArrivalCity;
        public string ArrivalLocation { get; set; } = ArrivalLocation;
        public string Destination { get; set; } = Destination;
        public DateTime ArrivalTime { get; set; } = ArrivalTime;
        public DateTime DestinationTime { get; set; } = DestinationTime;

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<RideEntity, RideListModel>();
            }
        }
    }
}