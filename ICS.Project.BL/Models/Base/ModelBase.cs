using System;

namespace ICS.Project.BL.Models.Base
{
    public abstract record ModelBase : IModel
    {
        public Guid Id { get; set; }
    }
}