using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS.Project.App.Views;
using ICS.Project.App.ViewModels;
using ICS.Project.App.ViewModels.Commands;
using ICS.Project.BL.Facades;
using ICS.Project.BL.Models;
using ICS.Project.App.ViewModels.Interfaces;
using ICS.Project.App.Services;
using ICS.Project.App.Messages;
using ICS.Project.App.Wrappers;
using ICS.Project.DAL.Entities.Types;
using System.Windows.Input;

namespace ICS.Project.App.ViewModels
{
    public class CarDetailViewModel : ViewModelBase, ICarDetailViewModel
    {
        private readonly IMediator _mediator;
        private readonly CarFacade _carFacade;
        private CarWrapper? _model = CarModel.Empty;

        public CarDetailViewModel(
            CarFacade carFacade,
            IMediator mediator)
        {
            _carFacade = carFacade;
            _mediator = mediator;

            SaveCommand = new AsyncRelayCommand(SaveAsync, CanSave);
            DeleteCommand = new AsyncRelayCommand(DeleteAsync);
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public CarWrapper? Model
        {
            get => _model;
            set
            {
                _model = value;
            }
        }


        public async Task LoadAsync(Guid id)
        {
            Model = await _carFacade.GetAsync(id) ?? CarModel.Empty;
        }

        public async Task SaveAsync()
        {
            if (Model == null)
            {
                throw new InvalidOperationException("Null model cannot be saved");
            }

            Model = await _carFacade.SaveAsync(Model.Model);
            _mediator.Send(new UpdateMessage<CarWrapper> { Model = Model });
        }

        private bool CanSave() => Model?.IsValid ?? false;

        public async Task DeleteAsync()
        {
            if (Model is null)
            {
                throw new InvalidOperationException("Null model cannot be deleted");
            }

            if (Model.Id != Guid.Empty)
            {
                await _carFacade.DeleteAsync(Model!.Id);    
            }
        }

        public override void LoadInDesignMode()
        {
            var seats = 4;
            base.LoadInDesignMode();
            Model = new CarWrapper(new CarModel(
                CarTypes.Sedan,
                Model: "Civic",
                Manufacturer: "Honda",
                DateOfRegistration: new DateTime(1993, 03, 03),
                NumberOfSeats: seats,
                ImageUrl: "",
                OwnerId: default!) 
            {
            });
        }
    }
}
