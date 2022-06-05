using AutoMapper;
using ICS.Project.DAL.Entities;
using ICS.Project.BL.Models.Base;

namespace ICS.Project.BL.Models
{
    public record UserListModel(
        string Name,
        string Surname) : ModelBase
    {
        public string Name { get; set; } = Name;
        public string Surname { get; set; } = Surname;
    }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, UserListModel>();
        }
    }
}