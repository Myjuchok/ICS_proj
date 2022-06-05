using ICS.Project.DAL.Entities;
using ICS.Project.DAL.Entities.Types;
using ICS.Project.BL.Models.Base;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace ICS.Project.BL.Models
{
    public record UserModel(
        UserTypes UserType,
        string Name,
        string Surname,
        DateTime DateOfBirth) : ModelBase
    {
        public UserTypes UserType { get; set; } = UserType;
        public string Name { get; set; } = Name;
        public string Surname { get; set; } = Surname;
        public DateTime DateOfBirth { get; set; } = DateOfBirth;
        public string? ImageUrl { get; set; }
        public List<CarListModel> Cars { get; init; } = new();
        public List<RideListModel> Rides { get; init; } = new();

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<UserEntity, UserModel>().ReverseMap();
            }
        }
        public static UserModel Empty => new(default, string.Empty, string.Empty, default);
    }
}