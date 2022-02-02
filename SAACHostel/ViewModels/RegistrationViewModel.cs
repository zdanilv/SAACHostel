using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using MvvmValidation;
using System.ComponentModel;
using System.Collections;
using SAACHostel.Services;
using System.Reactive.Threading.Tasks;

namespace SAACHostel.ViewModels
{
    internal class RegistrationViewModel : BindableBase, INotifyDataErrorInfo
    {
        private bool? isValid;
        private string validationErrorsString;
        protected ValidationHelper Validator { get; private set; }
        private NotifyDataErrorInfoAdapter NotifyDataErrorInfoAdapter { get; set; }
        public string ValidationErrorsString
        {
            get { return validationErrorsString; }
            private set { SetProperty(ref validationErrorsString, value); }
        }

        public bool? IsValid
        {
            get { return isValid; }
            private set { SetProperty(ref isValid, value); }
        }
        private IEventAggregator _eventAggregator;
        private byte[] _photo;
        private string _login;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private int _passport;
        private string _phoneNumber;
        private string _homeAddress;
        public byte[] Photo
        {
            get { return _photo; }
            set { SetProperty(ref _photo, value); Validator.ValidateAsync(nameof(Photo)); }
        }
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); Validator.ValidateAsync(nameof(Login)); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); Validator.ValidateAsync(nameof(Password)); }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); Validator.ValidateAsync(nameof(FirstName)); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); Validator.ValidateAsync(nameof(LastName)); }
        }
        public string MiddleName
        {
            get { return _middleName; }
            set { SetProperty(ref _middleName, value); Validator.ValidateAsync(nameof(MiddleName)); }
        }
        public int Passport
        {
            get { return _passport; }
            set { SetProperty(ref _passport, value); Validator.ValidateAsync(nameof(Passport)); }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); Validator.ValidateAsync(nameof(PhoneNumber)); }
        }
        public string HomeAddress
        {
            get { return _homeAddress; }
            set { SetProperty(ref _homeAddress, value); Validator.ValidateAsync(nameof(HomeAddress)); }
        }
        public DelegateCommand AddPhotoCommand { get; set; }
        public DelegateCommand RegistrationCommand { get; set; }
        public DelegateCommand BackCommand { get; set; }
        public RegistrationViewModel(IEventAggregator eventAggregator)
        {
            Validator = new ValidationHelper();
            NotifyDataErrorInfoAdapter = new NotifyDataErrorInfoAdapter(Validator);

            _eventAggregator = eventAggregator;
            AddPhotoCommand = new DelegateCommand(AddPhotoMethod);
            RegistrationCommand = new DelegateCommand(RegistrationMethod);
            BackCommand = new DelegateCommand(BackMethod);

            ConfigureValidationRules();
            Validator.ResultChanged += OnValidationResultChanged;
            Validate();
        }
        private void AddPhotoMethod()
        {
            Photo = Services.OpenDialogAddPhoto.ResultDialog();
        }
        private void RegistrationMethod()
        {
            Validate();
            if(Validator.GetResult() != null)
            {
                if (Validator.GetResult().IsValid == true)
                {
                    bool registrationState = Models.RegistrationModel.Registered(this);
                    _eventAggregator.GetEvent<Events.RegistrationViewSentEvent>().Publish(registrationState);
                    MessageBox.Show("Регистрация прошла успешно!");
                }
                else MessageBox.Show("Не все обязательные поля заполнены!");
            }
        }
        private void BackMethod()
        {
            bool registrationState = false;
            _eventAggregator.GetEvent<Events.RegistrationViewSentEvent>().Publish(registrationState);
        }
        private void ConfigureValidationRules()
        {
            Validator.AddRequiredRule(() => Photo, "Фотография обязательна");
            Validator.AddRequiredRule(() => Login, "Имя пользователя обязательно");
            Validator.AddRequiredRule(() => Password, "Пароль обязательно");
            Validator.AddRequiredRule(() => FirstName, "Имя обязательно");
            Validator.AddRequiredRule(() => LastName, "Фамилия обязательна");
            Validator.AddRequiredRule(() => MiddleName, "Отчество обязательно");
            Validator.AddRequiredRule(() => Passport, "Паспорт обязательно");
            Validator.AddRequiredRule(() => PhoneNumber, "Номер телефона обязательно");
            Validator.AddRequiredRule(() => HomeAddress, "Домашний адрес обязательно");

            Validator.AddAsyncRule(nameof(Login),
                async () =>
                {
                    var isAvailable = await UserRegistrationNameAvailable.IsUserNameAvailable(Login).ToTask();
                    return RuleResult.Assert(isAvailable,
                        string.Format("Логин {0} занят. Пожалуйста, выберите другой вариант.", Login));
                });
        }
        private async void Validate()
        {
            await ValidateAsync();
        }
        private async Task ValidateAsync()
        {
            var result = await Validator.ValidateAllAsync();

            UpdateValidationSummary(result);
        }
        private void OnValidationResultChanged(object sender, ValidationResultChangedEventArgs e)
        {
            if (!IsValid.GetValueOrDefault(true))
            {
                ValidationResult validationResult = Validator.GetResult();

                UpdateValidationSummary(validationResult);
            }
        }
        private void UpdateValidationSummary(ValidationResult validationResult)
        {
            IsValid = validationResult.IsValid;
            ValidationErrorsString = validationResult.ToString();
        }
        public IEnumerable GetErrors(string propertyName)
        {
            return NotifyDataErrorInfoAdapter.GetErrors(propertyName);
        }
        public bool HasErrors
        {
            get { return NotifyDataErrorInfoAdapter.HasErrors; }
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged
        {
            add { NotifyDataErrorInfoAdapter.ErrorsChanged += value; }
            remove { NotifyDataErrorInfoAdapter.ErrorsChanged -= value; }
        }
    }
}
