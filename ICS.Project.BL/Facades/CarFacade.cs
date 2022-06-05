using AutoMapper;
using ICS.Project.BL.Models;
using ICS.Project.DAL.Entities;
using ICS.Project.DAL.UnitOfWork;

namespace ICS.Project.BL.Facades;

public class CarFacade : CRUDFacade<CarEntity, CarListModel, CarModel>
{
    public CarFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
    {
    }
}