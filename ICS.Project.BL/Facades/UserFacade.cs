using AutoMapper;
using ICS.Project.BL.Models;
using ICS.Project.DAL.Entities;
using ICS.Project.DAL.UnitOfWork;

namespace ICS.Project.BL.Facades;

public class UserFacade : CRUDFacade<UserEntity, UserListModel, UserModel>
{
    public UserFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
    {
    }
}