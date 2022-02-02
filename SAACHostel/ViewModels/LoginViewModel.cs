using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace SAACHostel.ViewModels
{
    internal class LoginViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;

        private string _login = "admin";
        private string _password = "admin";
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand RegistrationCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }
        public LoginViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            LoginCommand = new DelegateCommand(LoginMethod);
            RegistrationCommand = new DelegateCommand(RegistrationMethod);
            ExitCommand = new DelegateCommand(ExitMethod);
        }
        private void LoginMethod()
        {
            bool loginState = Models.LoginModel.Logined(_login, _password);
            _eventAggregator.GetEvent<Events.LoginViewSentEvent>().Publish(loginState);
        }
        private void RegistrationMethod()
        {
            bool registrationState = true;
            _eventAggregator.GetEvent<Events.RegistrationViewSentEvent>().Publish(registrationState);
        }
        private void ExitMethod()
        {
            Application.Current.Shutdown();
        }
    }
}
