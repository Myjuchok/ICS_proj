using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using ICS.Project.BL.Models;
using ICS.Project.BL.Models.Base;
using ICS.Project.App.Extensions;
using ICS.Project.DAL.Entities.Types;

namespace ICS.Project.App.Wrappers
{
    public class UserWrapper : ModelWrapper<UserModel>
    {
        public UserWrapper(UserModel model)
            : base(model)
        {
            
        }

        public string? Name
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string? Surname
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public DateTime DateOfBirth
        {
            get => GetValue<DateTime>();
            set => SetValue(value);
        }
        public UserTypes UserType
        {
            get => GetValue<UserTypes>();
            set => SetValue(value);
        }
        public string? ImageUrl
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult($"{nameof(Name)} is required", new[] { nameof(Name) });
            }

            if (string.IsNullOrWhiteSpace(Surname))
            {
                yield return new ValidationResult($"{nameof(Surname)} is required", new[] { nameof(Surname) });
            }
        }

        public static implicit operator UserWrapper(UserModel detailModel)
            => new(detailModel);

        public static implicit operator UserModel(UserWrapper wrapper)
            => wrapper.Model;
    }
}
