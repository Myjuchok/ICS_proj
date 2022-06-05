using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS.Project.BL.Models;
using ICS.Project.DAL.Entities.Types;

namespace ICS.Project.App.Wrappers
{
    public class CarAmountWrapper : ModelWrapper<CarListModel>
    {
        public CarAmountWrapper(CarListModel model)
            : base(model)
        {

        }

        public CarTypes Type
        {
            get => GetValue<CarTypes>();
            set => SetValue(value);
        }
        public string? CarModel
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string? Manufacturer
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public int NumberOfSeats
        {
            get => GetValue<int>();
            set => SetValue(value);
        }

        public static implicit operator CarAmountWrapper(CarListModel listModel)
            => new(listModel);

        public static implicit operator CarListModel(CarAmountWrapper wrapper)
            => wrapper.Model;

    }
}
