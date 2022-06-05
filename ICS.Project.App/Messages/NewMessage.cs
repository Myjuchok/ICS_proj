using System;
using ICS.Project.BL.Models.Base;

namespace ICS.Project.App.Messages
{
    public record NewMessage<T> : Message<T>
        where T : IModel
    {
    }
}
