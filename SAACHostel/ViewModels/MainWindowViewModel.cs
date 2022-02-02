using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAACHostel.Views;
using System.Windows;
using Prism.Events;
using Prism.Modularity;
using Prism.Commands;

namespace SAACHostel.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        IDialogService _dialogService;
        private IEventAggregator _eventAggregator;
        private IContainerProvider _containerProvider;
        private IRegionManager _regionManager;
        private IRegion _region;
        private object _loginView;
        private object _registrationView;
        private object _journalsView;
        private Visibility _menuVisibility;
        public string DisplayName => "Общежитие";
        public Visibility MenuVisibility
        {
            get { return _menuVisibility; }
            set { SetProperty(ref _menuVisibility, value); }
        }
        public DelegateCommand LoadData { get; private set; }
        public DelegateCommand OpenProfileCommand { get; set; }
        public DelegateCommand LogoutAccountCommand { get; set; }
        public DelegateCommand OpenUniversityCommand { get; set; }
        public DelegateCommand OpenSettingsCommand { get; set; }
        public DelegateCommand OpenAboutCommand { get; set; }
        public MainWindowViewModel(IDialogService dialogService, IEventAggregator eventAggregator, IContainerProvider containerProvider, IRegionManager regionManager)
        {
            _dialogService = dialogService;
            _regionManager = regionManager;
            _containerProvider = containerProvider;

            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<Events.LoginViewSentEvent>().Subscribe(MainRegion);
            _eventAggregator.GetEvent<Events.RegistrationViewSentEvent>().Subscribe(RegistrationRegion);

            LoadData = new DelegateCommand(StartupRegion);
            OpenProfileCommand = new DelegateCommand(OpenProfileMethod);
            LogoutAccountCommand = new DelegateCommand(LogoutAccountMethod);
            OpenAboutCommand = new DelegateCommand(OpenAboutMethod);
            OpenUniversityCommand = new DelegateCommand(OpenUniversityMethod);
            OpenSettingsCommand = new DelegateCommand(OpenSettingsMethod);
            MenuVisibility = Visibility.Hidden;
        }
        private void StartupRegion()
        {
            _region = _regionManager.Regions["MainRegion"];
            _loginView = _containerProvider.Resolve<LoginView>();
            _region.Add(_loginView);
        }
        private void MainRegion(bool loginState) // Event receive
        {
            if (loginState)
            {
                _region.Deactivate(_loginView);
                _journalsView = _containerProvider.Resolve<JournalsView>();
                _region.Add(_journalsView);
                MenuVisibility = Visibility.Visible;
            }
        }
        private void RegistrationRegion(bool registrationState)
        {
            if (registrationState)
            {
                _region.Deactivate(_loginView);
                _registrationView = _containerProvider.Resolve<RegistrationView>();
                _region.Add(_registrationView);
            }
            else
            {
                _region.Deactivate(_registrationView);
                _region.Activate(_loginView);
            }
        }
        private void OpenProfileMethod()
        {
            var message = "Profile";
            _dialogService.ShowDialog("DialogProfileView", new DialogParameters($"message={message}"), r =>
            {
            });
        }
        private void LogoutAccountMethod()
        {
            bool logout = Models.LogoutModel.Logout();
            if (logout)
            {
                MenuVisibility = Visibility.Hidden;
                _region.Deactivate(_journalsView);
                _region.RemoveAll();
                StartupRegion();
            }
        }
        private void OpenUniversityMethod()
        {
            var message = "University";
            _dialogService.ShowDialog("DialogUniversityView", new DialogParameters($"message={message}"), r =>
            {
            });
        }
        private void OpenSettingsMethod()
        {
            var message = "Settings";
            _dialogService.ShowDialog("DialogSettingsView", new DialogParameters($"message={message}"), r =>
            {
            });
        }
        private void OpenAboutMethod()
        {
            var message = "About";
            _dialogService.ShowDialog("DialogAboutView", new DialogParameters($"message={message}"), r =>
            {
            });
        }
    }
}
