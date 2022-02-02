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
    internal class RoomItemInfoAdvancedViewModel : BindableBase, INotifyDataErrorInfo
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
        private int _hostel_id;
        private DateTime _dateCreate;
        private int _capacity;
        private string? _user_shortName;
        private string? _user_phone;
        private List<int> _hostel_items;
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
        public int Hostel_ID
        {
            get { return _hostel_id; }
            set { SetProperty(ref _hostel_id, value); Validator.ValidateAsync(nameof(Hostel_ID)); }
        }
        public DateTime DateCreate
        {
            get { return _dateCreate; }
            set { SetProperty(ref _dateCreate, value); }
        }
        public int Capacity
        {
            get { return _capacity; }
            set { SetProperty(ref _capacity, value); Validator.ValidateAsync(nameof(Capacity)); }
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
        public List<int> Hostel_Items
        {
            get { return _hostel_items; }
            set { SetProperty(ref _hostel_items, value); }
        }
        public DelegateCommand SaveItemCommand { get; set; }
        public DelegateCommand ChangeItemCommand { get; set; }
        public RoomItemInfoAdvancedViewModel(IEventAggregator eventAggregator)
        {
            Validator = new ValidationHelper();
            NotifyDataErrorInfoAdapter = new NotifyDataErrorInfoAdapter(Validator);
            _eventAggregator = eventAggregator;

            VisibilityEditing = Visibility.Hidden;
            VisibilityViewing = Visibility.Visible;
            SaveItemCommand = new DelegateCommand(SaveItemMethod);
            ChangeItemCommand = new DelegateCommand(ChangeItemMethod);
            _hostel_items = new List<int>();
            UpdateHostelItems();
            ConfigureValidationRules();
            Validator.ResultChanged += OnValidationResultChanged;
            Validate();
        }
        private void UpdateHostelItems()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.Hostel hostel in dataBase.Hostels)
                {
                    _hostel_items.Add(hostel.ID);
                }
            }
        }
        private void SaveItemMethod()
        {
            Validate();
            if (Validator.GetResult() != null)
            {
                if (Validator.GetResult().IsValid == true)
                {
                    if (_isnew)
                        Models.RoomItemSaveDataBase.SaveDataBase(this);
                    else Models.RoomItemSaveDataBase.ChangeDataBase(this);
                    _eventAggregator.GetEvent<Events.RoomListUpdateEvent>().Publish();
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
            Validator.AddRequiredRule(() => Hostel_ID, "Номер телефона обязательно");
            Validator.AddRequiredRule(() => Capacity, "Количество комнат обязательно");

            Validator.AddRule(nameof(Hostel_ID), () => RuleResult.Assert(Hostel_ID != 0, "Общежитие обязательно"));
            Validator.AddRule(nameof(Capacity), () => RuleResult.Assert(Capacity != 0, "Количество мест обязательно"));
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
