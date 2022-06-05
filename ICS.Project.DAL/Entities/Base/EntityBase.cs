using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICS.Project.DAL.Entities.Base
{
    public abstract record EntityBase : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}