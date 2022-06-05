using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ICS.Project.BL.Models.Base;
using ICS.Project.App.ViewModels;
using ICS.Project.BL.Models;

namespace ICS.Project.App.Wrappers
{
    public class RideAmountWrapper : ModelWrapper<RideListModel>
    {
        public RideAmountWrapper(RideListModel model)
            : base(model)
        {

        }
        public string? ArrivalCity
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string? ArrivalLocation
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string? Destination
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public DateTime ArrivalTime
        {
            get => GetValue<DateTime>();
            set => SetValue(value);
        }
        public DateTime? DestinationTime
        {
            get => GetValue<DateTime?>();
            set => SetValue(value);
        }

        public static implicit operator RideAmountWrapper(RideListModel listModel)
            => new(listModel);

        public static implicit operator RideListModel(RideAmountWrapper wrapper)
            => wrapper.Model;
    }
}
