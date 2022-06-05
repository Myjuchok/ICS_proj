using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS.Project.BL.Models;
using ICS.Project.DAL.Entities.Types;

namespace ICS.Project.App.Wrappers
{
    public class CarWrapper : ModelWrapper<CarModel>
    {
        public CarWrapper(CarModel model)
            : base(model)
        {
        }

        public CarTypes Type
        {
            get => GetValue<CarTypes>();
            set => SetValue(value);
        }
        public string? Cmodel
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string? Manufacturer
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public DateTime DateofRegistration
        {
            get => GetValue<DateTime>();
            set => SetValue(value);
        }
        public int? NumberOfSeats
        {
            get => GetValue<int>();
            set => SetValue(value);
        }
        public string? ImageUrl
        {
            get => GetValue<string>();
            set => SetValue(value);
        }


        public static implicit operator CarWrapper(CarModel detailModel)
            => new(detailModel);

        public static implicit operator CarModel(CarWrapper wrapper)
            => wrapper.Model;
    }
}
