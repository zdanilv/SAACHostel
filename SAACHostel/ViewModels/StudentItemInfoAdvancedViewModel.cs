using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using MvvmValidation;
using System.ComponentModel;
using System.Collections;
using SAACHostel.Services;
using System.Reactive.Threading.Tasks;
using SAACHostel.Models;

namespace SAACHostel.ViewModels
{
    internal class StudentItemInfoAdvancedViewModel : BindableBase, INotifyDataErrorInfo
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
        private byte[]? _student_photo;
        private string? _student_firstName;
        private string? _student_lastName;
        private string? _student_middleName;
        private string? _student_faculty;
        private string? _student_specialty;
        private string? _student_group;
        private int _student_passport;
        private string? _student_phone;
        private string? _student_homeAddress;
        private string? _user_shortName;
        private string? _user_phone;
        private List<FacultyItem> _facultyItems;
        private FacultyItem _selectedFacultyItems;
        private List<SpecialtyItem> _specialtyItems;
        private SpecialtyItem _selectedSpecialtyItems;
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
        public byte[]? Student_Photo
        {
            get { return _student_photo; }
            set { SetProperty(ref _student_photo, value); Validator.ValidateAsync(nameof(Student_Photo)); }
        }
        public string? Student_FirstName
        {
            get { return _student_firstName; }
            set { SetProperty(ref _student_firstName, value); Validator.ValidateAsync(nameof(Student_FirstName)); }
        }
        public string? Student_LastName
        {
            get { return _student_lastName; }
            set { SetProperty(ref _student_lastName, value); Validator.ValidateAsync(nameof(Student_LastName)); }
        }
        public string? Student_MiddleName
        {
            get { return _student_middleName; }
            set { SetProperty(ref _student_middleName, value); Validator.ValidateAsync(nameof(Student_MiddleName)); }
        }
        public string? Student_Faculty
        {
            get { return _student_faculty; }
            set { SetProperty(ref _student_faculty, value); }
        }
        public string? Student_Specialty
        {
            get { return _student_specialty; }
            set { SetProperty(ref _student_specialty, value); }
        }
        public string? Student_Group
        {
            get { return _student_group; }
            set { SetProperty(ref _student_group, value); Validator.ValidateAsync(nameof(Student_Group)); }
        }
        public int Student_Passport
        {
            get { return _student_passport; }
            set { SetProperty(ref _student_passport, value); Validator.ValidateAsync(nameof(Student_Passport)); }
        }
        public string? Student_Phone
        {
            get { return _student_phone; }
            set { SetProperty(ref _student_phone, value); Validator.ValidateAsync(nameof(Student_Phone)); }
        }
        public string? Student_HomeAddress
        {
            get { return _student_homeAddress; }
            set { SetProperty(ref _student_homeAddress, value); Validator.ValidateAsync(nameof(Student_HomeAddress)); }
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
        public FacultyItem SelectedFacultyItems
        {
            get { return _selectedFacultyItems; }
            set { SetProperty(ref _selectedFacultyItems, value); Student_Faculty = _selectedFacultyItems.Name; Validator.ValidateAsync(nameof(SelectedFacultyItems)); }
        }
        public SpecialtyItem SelectedSpecialtyItems
        {
            get { return _selectedSpecialtyItems; }
            set { SetProperty(ref _selectedSpecialtyItems, value); Student_Specialty = _selectedSpecialtyItems.Name; Validator.ValidateAsync(nameof(SelectedSpecialtyItems)); }
        }
        public DelegateCommand SaveItemCommand { get; set; }
        public DelegateCommand ChangeItemCommand { get; set; }
        public DelegateCommand ChangePhotoCommand { get; set; }
        public StudentItemInfoAdvancedViewModel(IEventAggregator eventAggregator)
        {
            Validator = new ValidationHelper();
            NotifyDataErrorInfoAdapter = new NotifyDataErrorInfoAdapter(Validator);
            _eventAggregator = eventAggregator;
            VisibilityEditing = Visibility.Hidden;
            VisibilityViewing = Visibility.Visible;
            SaveItemCommand = new DelegateCommand(SaveItemMethod);
            ChangeItemCommand = new DelegateCommand(ChangeItemMethod);
            ChangePhotoCommand = new DelegateCommand(ChangePhotoMethod);
            _facultyItems = new List<FacultyItem>();
            _specialtyItems = new List<SpecialtyItem>();
            AddFacultyItem();
            AddSpecialtyItem();
            ConfigureValidationRules();
            Validator.ResultChanged += OnValidationResultChanged;
            Validate();
        }
        private void AddFacultyItem()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.Faculty faculty in dataBase.Facultys)
                {
                    _facultyItems.Add(new FacultyItem()
                    {
                        ID = faculty.ID,
                        Name = faculty.Full_Name
                    });
                }
            }
        }
        private void AddSpecialtyItem()
        {
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.Specialty specialty in dataBase.Specialtys)
                {
                    _specialtyItems.Add(new SpecialtyItem()
                    {
                        ID = specialty.ID,
                        Name = specialty.Full_Name
                    });
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
                        Models.StudentItemSaveDataBase.SaveDataBase(this);
                    else
                        Models.StudentItemSaveDataBase.ChangeDataBase(this);
                    _eventAggregator.GetEvent<Events.StudentListUpdateEvent>().Publish();
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
        private void ChangePhotoMethod()
        {
            Student_Photo = Services.OpenDialogAddPhoto.ResultDialog();
            Validate();
        }
        public List<FacultyItem> FacultyItems
        {
            get { return _facultyItems; }
        }
        public List<SpecialtyItem> SpecialtyItems
        {
            get { return _specialtyItems; }
        }
        private void ConfigureValidationRules()
        {
            Validator.AddRequiredRule(() => Student_Photo, "Фотография обязательна");
            Validator.AddRequiredRule(() => Student_FirstName, "Имя обязательно");
            Validator.AddRequiredRule(() => Student_LastName, "Фамилия обязательна");
            Validator.AddRequiredRule(() => Student_MiddleName, "Отчество обязательно");
            Validator.AddRequiredRule(() => Student_Passport, "Паспорт обязательно");
            Validator.AddRequiredRule(() => SelectedFacultyItems, "Факультет обязательно");
            Validator.AddRequiredRule(() => SelectedSpecialtyItems, "Специальность обязательно");
            Validator.AddRequiredRule(() => Student_Group, "Группа обязательно");
            Validator.AddRequiredRule(() => Student_Phone, "Номер телефона обязательно");
            Validator.AddRequiredRule(() => Student_HomeAddress, "Домашний адрес обязательно");

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
    internal class FacultyItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    internal class SpecialtyItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
