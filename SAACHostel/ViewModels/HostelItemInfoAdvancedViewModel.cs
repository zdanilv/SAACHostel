using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MvvmValidation;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using SAACHostel.Models;

namespace SAACHostel.ViewModels
{
    internal class HostelItemInfoAdvancedViewModel : BindableBase, INotifyDataErrorInfo
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
        private Visibility _visibilityViewing;
        private Visibility _visibilityEditing;
        private bool _isnew;
        private bool _isReadOnly;
        private bool _isEnabledSaveButton;
        private int _id;
        private int _user_id;
        private DateTime _dateCreate;
        private string? _phone;
        private int _count_rooms;
        private string? _home_address;
        private string? _user_shortName;
        private string? _user_phone;
        public Visibility VisibilityViewing
        {
            get { return _visibilityViewing; }
            set { SetProperty(ref _visibilityViewing, value); }
        }
        public Visibility VisibilityEditing
        {
            get { return _visibilityEditing; }
            set { SetProperty(ref _visibilityEditing, value); }
        }
        public bool IsNew
        {
            get { return _isnew; }
            set { SetProperty(ref _isnew, value); }
        }
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set { SetProperty(ref _isReadOnly, value); }
        }
        public bool IsEnabledSaveButton
        {
            get { return _isEnabledSaveButton; }
            set { SetProperty(ref _isEnabledSaveButton, value); }
        }
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        public int User_ID
        {
            get { return _user_id; }
            set { SetProperty(ref _user_id, value); }
        }
        public DateTime DateCreate
        {
            get { return _dateCreate; }
            set { SetProperty(ref _dateCreate, value); }
        }
        public string? Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); Validator.ValidateAsync(nameof(Phone)); }
        }
        public int Count_Rooms
        {
            get { return _count_rooms; }
            set { SetProperty(ref _count_rooms, value); Validator.ValidateAsync(nameof(Count_Rooms)); }
        }
        public string? Home_Address
        {
            get { return _home_address; }
            set { SetProperty(ref _home_address, value); Validator.ValidateAsync(nameof(Home_Address)); }
        }
        public string? User_ShortName
        {
            get { return _user_shortName; }
            set { SetProperty(ref _user_shortName, value); }
        }
        public string? User_Phone
        {
            get { return _user_phone; }
            set { SetProperty(ref _user_phone, value); }
        }
        public DelegateCommand SaveItemCommand { get; set; }
        public DelegateCommand ChangeItemCommand { get; set; }

        public HostelItemInfoAdvancedViewModel(IEventAggregator eventAggregator)
        {
            Validator = new ValidationHelper();
            NotifyDataErrorInfoAdapter = new NotifyDataErrorInfoAdapter(Validator);
            _eventAggregator = eventAggregator;
            VisibilityEditing = Visibility.Hidden;
            VisibilityViewing = Visibility.Visible;
            SaveItemCommand = new DelegateCommand(SaveItemMethod);
            ChangeItemCommand = new DelegateCommand(ChangeItemMethod);
            ConfigureValidationRules();
            Validator.ResultChanged += OnValidationResultChanged;
            Validate();
        }
        private void SaveItemMethod()
        {
            Validate();
            if (Validator.GetResult() != null)
            {
                if (Validator.GetResult().IsValid == true)
                {
                    if (_isnew)
                        Models.HostelItemSaveDataBase.SaveDataBase(this);
                    else Models.HostelItemSaveDataBase.ChangeDataBase(this);
                    _eventAggregator.GetEvent<Events.HostelListUpdateEvent>().Publish();
                    MessageBox.Show("Данные сохранены в базе данных!");
                    IsReadOnly = true;
                    IsEnabledSaveButton = false;
                    VisibilityEditing = Visibility.Hidden;
                    VisibilityViewing = Visibility.Visible;
                }
                else MessageBox.Show("Не все обязательные поля заполнены!");
            }
        }
        private void ChangeItemMethod()
        {
            IsReadOnly = false;
            IsEnabledSaveButton = true;
            VisibilityViewing = Visibility.Hidden;
            VisibilityEditing = Visibility.Visible;
            Validate();
        }
        private void ConfigureValidationRules()
        {
            Validator.AddRequiredRule(() => Phone, "Номер телефона обязательно");
            Validator.AddRequiredRule(() => Count_Rooms, "Количество комнат обязательно");
            Validator.AddRequiredRule(() => Home_Address, "Адрес обязательно");

            Validator.AddRule(nameof(Count_Rooms), () => RuleResult.Assert(Count_Rooms != 0, "Количество комнат обязательно!"));
            Validator.AddRule(nameof(Home_Address), () => RuleResult.Assert(Home_Address != "", "Количество комнат обязательно!"));
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
