using AutoMapper;
using ICS.Project.DAL.Entities;
using ICS.Project.DAL.Entities.Types;
using ICS.Project.BL.Models.Base;

namespace ICS.Project.BL.Models
{
    public record CarListModel(
        CarTypes Type,
        string Model,
        string Manufacturer,
        int NumberOfSeats) : ModelBase
    {
        public CarTypes Type { get; set; } = Type;
        public string Model { get; set; } = Model;
        public string Manufacturer { get; set; } = Manufacturer;
        public int NumberOfSeats { get; set; } = NumberOfSeats;

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<CarEntity, CarListModel>();
            }
        }
    }
}