using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using SAACHostel.Models;
using MvvmValidation;
using System.ComponentModel;
using System.Collections;
using System.Reactive.Threading.Tasks;

namespace SAACHostel.ViewModels
{
    internal class JournalItemInfoAdvancedViewModel : BindableBase, INotifyDataErrorInfo
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
        private bool _isEnabledRoom;
        private int _id;
        private DateTime _dateCreate;
        private DateTime _date_ent = DateTime.Now;
        private DateTime _date_ext = DateTime.Now;
        private int _hostel_id;
        

        private int _room_id;
        private int _student_id;
        private int _user_id;
        private int _paymentAndPeriod_id;
        private int _pay;
        private string? _stateName;
        private ComboBoxState _state;
        private string _selectedPaymentPeriod;
        private int _totalPaid;
        private byte[]? _student_photo;
        private string? _student_firstName;
        private string? _student_lastName;
        private string? _student_middleName;
        private int _student_faculty;
        private int _student_specialty;
        private string? _student_group;
        private int _student_passport;
        private string? _student_phone;
        private string? _student_homeAddress;
        private string? _user_shortName;
        private string? _user_phone;
        private List<int> _hostel_items;
        private List<int> _room_items;
        private List<ComboBoxState> _state_items;
        private List<StudentItem> _student_items;
        private StudentItem _student;
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
        public bool IsEnabledRoom
        {
            get { return _isEnabledRoom; }
            set { SetProperty(ref _isEnabledRoom, value); }
        }
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        public DateTime DateCreate
        {
            get { return _dateCreate; }
            set { SetProperty(ref _dateCreate, value); }
        }
        public DateTime Date_Ent
        {
            get { return _date_ent; }
            set { SetProperty(ref _date_ent, value); Validator.ValidateAll(); GetTotalPaid(); }
        }
        public DateTime Date_Ext
        {
            get { return _date_ext; }
            set { SetProperty(ref _date_ext, value); Validator.ValidateAll(); GetTotalPaid(); }
        }
        public int Hostel_ID
        {
            get { return _hostel_id; }
            set { SetProperty(ref _hostel_id, value); if(Hostel_ID != 0 & Hostel_ID != null) IsEnabledRoom = true; Validator.ValidateAsync(nameof(Hostel_ID)); }
        }
        public int Room_ID
        {
            get { return _room_id; }
            set { SetProperty(ref _room_id, value); Validator.ValidateAsync(nameof(Room_ID)); }
        }
        public int Student_ID
        {
            get { return _student_id; }
            set { SetProperty(ref _student_id, value); }
        }
        public int User_ID
        {
            get { return _user_id; }
            set { SetProperty(ref _user_id, value); }
        }
        public int PaymentAndPeriod_ID
        {
            get { return _paymentAndPeriod_id; }
            set { SetProperty(ref _paymentAndPeriod_id, value); ConfigureValidationRules(); Validate(); }
        }
        public int Pay
        {
            get { return _pay; }
            set { SetProperty(ref _pay, value); Validator.ValidateAsync(nameof(Pay)); }
        }
        public string StateName
        {
            get { return _stateName; }
            set { SetProperty(ref _stateName, value); }
        }
        public string SelectedPaymentPeriod
        {
            get { return _selectedPaymentPeriod; }
            set { SetProperty(ref _selectedPaymentPeriod, value); Validator.ValidateAsync(nameof(SelectedPaymentPeriod)); }
        }
        public int TotalPaid
        {
            get { return _totalPaid; }
            set { SetProperty(ref _totalPaid, value); }
        }
        public ComboBoxState State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); StateName = _state.Name_State; Validator.ValidateAsync(nameof(State)); }
        }
        public byte[]? Student_Photo
        {
            get { return _student_photo; }
            set { SetProperty(ref _student_photo, value); }
        }
        public string? Student_FirstName
        {
            get { return _student_firstName; }
            set { SetProperty(ref _student_firstName, value); }
        }
        public string? Student_LastName
        {
            get { return _student_lastName; }
            set { SetProperty(ref _student_lastName, value); }
        }
        public string? Student_MiddleName
        {
            get { return _student_middleName; }
            set { SetProperty(ref _student_middleName, value); }
        }
        public int Student_Faculty
        {
            get { return _student_faculty; }
            set { SetProperty(ref _student_faculty, value); }
        }
        public int Student_Specialty
        {
            get { return _student_specialty; }
            set { SetProperty(ref _student_specialty, value); }
        }
        public string? Student_Group
        {
            get { return _student_group; }
            set { SetProperty(ref _student_group, value); }
        }
        public int Student_Passport
        {
            get { return _student_passport; }
            set { SetProperty(ref _student_passport, value); }
        }
        public string? Student_Phone
        {
            get { return _student_phone; }
            set { SetProperty(ref _student_phone, value); }
        }
        public string? Student_HomeAddress
        {
            get { return _student_homeAddress; }
            set { SetProperty(ref _student_homeAddress, value); }
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
        public List<int> Room_Items
        {
            get { return _room_items; }
            set { SetProperty(ref _room_items, value); }
        }
        public List<ComboBoxState> State_Items
        {
            get { return _state_items; }
            set { SetProperty(ref _state_items, value); }
        }
        public List<StudentItem> Student_Items
        {
            get { return _student_items; }
            set { SetProperty(ref _student_items, value); }
        }
        public StudentItem Student
        {
            get { return _student; }
            set
            {
                SetProperty(ref _student, value);
                UpdateStudentItem(_student.ID);
                Validator.ValidateAsync(nameof(Student));
            }
        }
        public DelegateCommand SaveItemCommand { get; set; }
        public DelegateCommand ChangeItemCommand { get; set; }
        public JournalItemInfoAdvancedViewModel(IEventAggregator eventAggregator)
        {
            Validator = new ValidationHelper();
            NotifyDataErrorInfoAdapter = new NotifyDataErrorInfoAdapter(Validator);
            _eventAggregator = eventAggregator;
            VisibilityEditing = Visibility.Hidden;
            VisibilityViewing = Visibility.Visible;
            SaveItemCommand = new DelegateCommand(SaveItemMethod);
            ChangeItemCommand = new DelegateCommand(ChangeItemMethod);
            _hostel_items = new List<int>();
            _room_items = new List<int>();
            _state_items = new List<ComboBoxState>();
            _student_items = new List<StudentItem>();
            UpdateHostelItems();
            UpdateRoomItems();
            UpdateStateItems();
            UpdateStudentItems();
            Validator.ResultChanged += OnValidationResultChanged;
            if(Hostel_ID != 0 & Hostel_ID != null)
                IsEnabledRoom = true;
        }
        private void GetTotalPaid()
        {
            if (Validator.ValidateAll().IsValid)
            {
                if (_paymentAndPeriod_id == 3)
                {
                    var tacts = Date_Ent.Month - Date_Ext.Month;
                    TotalPaid = (_pay * tacts);
                }
                if (_paymentAndPeriod_id == 2)
                {
                    var tacts = (Date_Ent - Date_Ext).TotalDays / 7;
                    TotalPaid = (int)(_pay * tacts);
                }
                if (_paymentAndPeriod_id == 1)
                {
                    var tacts = (Date_Ent - Date_Ext).TotalDays;
                    TotalPaid = (int)(_pay * tacts);
                }
            }
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
        private void UpdateRoomItems()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.Room room in dataBase.Rooms)
                {
                    _room_items.Add(room.ID);
                }
            }
        }
        private void UpdateStateItems()
        {
            _state_items.Add(new ComboBoxState { State = true, Name_State = "Оплачено" });
            _state_items.Add(new ComboBoxState { State = false, Name_State = "Не оплачено" });
        }
        private void UpdateStudentItems()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.Student student in dataBase.Students)
                {
                    string[] fullName = new string[] { student.First_Name, student.Middle_Name, student.Last_Name };
                    _student_items.Add(new StudentItem { ID = student.ID, FullName = String.Join(" ", fullName) });
                }
            }
        }
        private void UpdateStudentItem(int _id)
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.Student student in dataBase.Students)
                {
                    if (student.ID == _id)
                    {
                        Student_ID = student.ID;
                        Student_Photo = student.Photo;
                        Student_FirstName = student.First_Name;
                        Student_LastName = student.Last_Name;
                        Student_MiddleName = student.Middle_Name;
                        Student_Faculty = student.FacultyID;
                        Student_Specialty = student.SpecialtyID;
                        Student_Group = student.Group;
                        Student_Passport = student.Passport_ID;
                        Student_Phone = student.Phone;
                        Student_HomeAddress = student.Home_address;
                    }
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
                        Models.JournalItemSaveDataBase.SaveDataBase(this);
                    else Models.JournalItemSaveDataBase.ChangeDataBase(this);
                    _eventAggregator.GetEvent<Events.JournalListUpdateEvent>().Publish();
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
            Validator.AddRequiredRule(() => Student_Phone, "Студент обязательно");
            Validator.AddRequiredRule(() => Date_Ent, "Дата заселения обязательно");
            Validator.AddRequiredRule(() => Date_Ext, "Дата выселения обязательно");
            Validator.AddRequiredRule(() => Hostel_ID, "Общежитие обязательно");
            Validator.AddRequiredRule(() => Room_ID, "Комната обязательно");
            Validator.AddRequiredRule(() => State, "Статус обязательно");

            Validator.AddRule(nameof(Pay), () => RuleResult.Assert(Pay != null & Pay != 0, "Не указана оплата в настройках оплаты!"));
            Validator.AddRule(nameof(SelectedPaymentPeriod), () => RuleResult.Assert(SelectedPaymentPeriod != null & SelectedPaymentPeriod != "", "Не указан период оплаты в настройках оплаты!"));

            Validator.AddRule(nameof(Date_Ent),() => RuleResult.Assert(Date_Ent != new DateTime(), "Неверная дата заселения!"));
            Validator.AddRule(nameof(Date_Ext), () => RuleResult.Assert(Date_Ext != new DateTime(), "Неверная дата выселения!"));
            Validator.AddRule(nameof(Hostel_ID), () => RuleResult.Assert(Hostel_ID != 0, "Неверно выбрано общежитие!"));
            Validator.AddRule(nameof(Room_ID), () => RuleResult.Assert(Room_ID != 0, "Неверно выбрана комната!"));
            if(_paymentAndPeriod_id == 3)
            {
                MessageBox.Show("Месяц");
                Validator.AddRule(nameof(Date_Ent), nameof(Date_Ext), () => RuleResult.Assert((Date_Ent.Year - Date_Ext.Year) <= 0 && (Date_Ent.Month - Date_Ext.Month) <= 0, "Дата выселения не может быть менее чем через месяц!"));
                Validator.AddRule(nameof(Date_Ent), nameof(Date_Ext), () => RuleResult.Assert((Date_Ent.Day - Date_Ext.Day) == 0, "День выселения должен совпадать с днем заселения!"));
            }
            if(_paymentAndPeriod_id == 2)
            {
                MessageBox.Show("7 дней");
                Validator.AddRule(nameof(Date_Ent), nameof(Date_Ext), () => RuleResult.Assert((Date_Ent.Year - Date_Ext.Year) <= 0 && (Date_Ent.Month - Date_Ext.Month) <= 0, "Дата выселения не может быть менее чем через 7 дней!"));
                Validator.AddRule(nameof(Date_Ent), nameof(Date_Ext), () => RuleResult.Assert(((Date_Ent.Day - Date_Ext.Day) % 7) == 0, "Дата выселения должна быть кратна 7 дням после заселения!"));
            }
            if (_paymentAndPeriod_id == 1)
            {
                MessageBox.Show("1 день");
                Validator.AddRule(nameof(Date_Ent), nameof(Date_Ext), () => RuleResult.Assert((Date_Ent.Year - Date_Ext.Year) <= 0 && (Date_Ent.Month - Date_Ext.Month) <= 0, "Дата выселения не может быть менее чем через 1 день!"));
            }
            Validator.AddRule(nameof(Date_Ent), nameof(Date_Ext), () => RuleResult.Assert(Date_Ext > Date_Ent, "Дата выселения не может быть раньше чем дата заезда!"));
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
    internal class ComboBoxState
    {
        public bool State { get; set; }
        public string? Name_State { get; set; }
    }
    internal class StudentItem
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
    }

}
