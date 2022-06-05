using ICS.Project.DAL.Entities.Types;
using AutoMapper;
using ICS.Project.DAL.Entities;
using ICS.Project.BL.Models.Base;
using System;
using Microsoft.EntityFrameworkCore;

namespace ICS.Project.BL.Models
{
    public record CarModel(
    CarTypes Type,
    string Model,
    string Manufacturer,
    DateTime DateOfRegistration,
    int NumberOfSeats,
    string? ImageUrl,
    Guid OwnerId) : ModelBase
    {
        public CarTypes Type { get; set; } = Type;
        public string Model { get; set; } = Model;
        public string Manufacturer { get; set; } = Manufacturer;
        public DateTime DateOfRegistration { get; set; } = DateOfRegistration;
        public int NumberOfSeats { get; set; } = NumberOfSeats;
        public string? ImageUrl { get; set; } = ImageUrl;
        public Guid OwnerId { get; set; } = OwnerId;

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<CarEntity, CarModel>().ReverseMap();
            }
        }

        public static CarModel Empty => new(CarTypes.None, string.Empty, string.Empty, default, default, default!, default!);
    }
}