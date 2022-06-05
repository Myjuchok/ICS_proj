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
    public class UserDetailViewModel : ViewModelBase, IUserDetailViewModel
    {
        private readonly IMediator _mediator;
        private readonly UserFacade _userFacade;
        private UserWrapper? _model = UserModel.Empty;
        
        public UserDetailViewModel(
            UserFacade userfacade,
            IMediator mediator)
        {
            _userFacade = userfacade;
            _mediator = mediator;

            SaveCommand = new AsyncRelayCommand(SaveAsync, CanSave);
            DeleteCommand = new AsyncRelayCommand(DeleteAsync);
            OpenWindowCommand = new RelayCommand(OpenProfileWindow);

        }

        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand OpenWindowCommand { get; }

        public UserWrapper? Model
        {
            get => _model;
            set
            {
                _model = value;
            }
        }

        public async Task LoadAsync(Guid id) => Model = await _userFacade.GetAsync(id) ?? UserModel.Empty;

        public async Task DeleteAsync()
        {
            if(Model is null)
            {
                throw new InvalidOperationException("Null model cannot be deleted");
            }
            if(Model.Id != Guid.Empty)
            {

                await _userFacade.DeleteAsync(Model!.Id);

            }
        }

        private bool CanSave() => Model?.IsValid ?? false;

        public async Task SaveAsync()
        {
            if(Model == null)
            {
                throw new InvalidOperationException("Null model cannot be saved");
            }
            Model = await _userFacade.SaveAsync(Model);
            _mediator.Send(new UpdateMessage<UserWrapper> { Model = Model});
        }

        public void OpenProfileWindow()
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            
        }

        public override void LoadInDesignMode()
        {
            base.LoadInDesignMode();
            Model = new UserWrapper(new UserModel(
                UserTypes.Driver,
                Name: "Nate",
                Surname: "Jhonson",
                DateOfBirth: new DateTime(1990, 05, 09)
                )
            {
                ImageUrl = "https://www.kindpng.com/picc/m/53-533409_portrait-clipart-random-person-random-person-cartoon-hd.png"
            });
        }
    }
}
