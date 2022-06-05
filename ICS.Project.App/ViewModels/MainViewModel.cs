using ICS.Project.App.Factories;
using ICS.Project.App.Messages;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ICS.Project.App.ViewModels.Interfaces;
using ICS.Project.App.Services;
using ICS.Project.App.ViewModels;

namespace ICS.Project.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IFactory<IUserDetailViewModel> _userDetailViewModelFactory;
        private readonly IFactory<ICarDetailViewModel> _carDetailViewModelFactory;

        public MainViewModel(
            IMediator mediator,
            IFactory<IUserDetailViewModel> userDetailViewModelFactory,
            IFactory<ICarDetailViewModel> carDetailViewModelFactory)

        {
            _userDetailViewModelFactory = userDetailViewModelFactory;
            _carDetailViewModelFactory = carDetailViewModelFactory;

            UserDetailViewModel = _userDetailViewModelFactory.Create();
            CarDetailViewModel = _carDetailViewModelFactory.Create();
        }

        public IUserDetailViewModel UserDetailViewModel { get; }
        public ICarDetailViewModel CarDetailViewModel { get; }

    }
}