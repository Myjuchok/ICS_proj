using AutoMapper;
using ICS.Project.BL.Models;
using ICS.Project.DAL.Entities;
using ICS.Project.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICS.Project.BL.Facades;

public class RideFacade : CRUDFacade<RideEntity, RideListModel, RideModel>
{

    private readonly IMapper _mapper;
    private readonly IUnitOfWorkFactory _unitOfWorkFactory;

    public RideFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RideListModel>> GetFilteredAsync(FilterParams filterParams)
    {
        await using var uow = _unitOfWorkFactory.Create();
        var query = uow
            .GetRepository<RideEntity>()
            .Get();
        if (filterParams.ArrivalTime != default) query = query.Where(e => e.ArrivalTime >= filterParams.ArrivalTime);
        if (filterParams.Start != null) query = query.Where(e => e.ArrivalCity == filterParams.Start);
        if (filterParams.End != null) query = query.Where(e => e.Destination == filterParams.End);

        return await _mapper.ProjectTo<RideListModel>(query).ToListAsync().ConfigureAwait(false);
    }
}

public class FilterParams
{
    public DateTime ArrivalTime { get; set; }
    public string? Start { get; set; }
    public string? End { get; set; }

}