using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS.Project.BL.Models;
using ICS.Project.DAL.Entities.Types;

namespace ICS.Project.App.Wrappers
{
    public class RideWrapper : ModelWrapper<RideModel>
    {
        public RideWrapper(RideModel model)
            : base(model)
        {
        }

        public string? ArrivalCiry
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string? ArrivalLocation
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string? Duration
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public DateTime ArrivalTime
        {
            get => GetValue<DateTime>();
            set => SetValue(value);
        }
        public DateTime DestinationTime
        {
            get => GetValue<DateTime>();
            set => SetValue(value);
        }
        public Guid? Driver
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }
        public Guid? Car
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        public static implicit operator RideWrapper(RideModel detailModel)
            => new(detailModel);

        public static implicit operator RideModel(RideWrapper wrapper)
            => wrapper.Model;
    }
}
