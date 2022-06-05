using System;
using System.Threading.Tasks;

namespace ICS.Project.App.ViewModels
{
    public interface IDetailViewModel<out TDetail> : IViewModel
    {
        TDetail? Model { get; }
        Task LoadAsync (Guid id);
        Task DeleteAsync ();
        Task SaveAsync ();
    }
}