using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAACHostel.ViewModels
{
    internal class DialogUniversityViewModel : DialogViewModelBase
    {
        private ObservableCollection<FacultyListItem> _itemsFaculty;
        private ObservableCollection<SpecialtyListItem> _itemsSpecialty;
        private FacultyListItem _selectedFacultyItem;
        private SpecialtyListItem _selectedSpecialtyItem;
        private string _facultyFullName;
        private string _facultyDecanFullName;
        private string _facultyPhoneDecan;
        private string _facultyShortName;
        private string _specialtyFullName;
        private string _specialtyShortName;
        private bool _isEnableChangeFaculty = false;
        private bool _isEnableChangeSpecialty = false;
        private bool _isExpandedFacultyAdd = false;
        private bool _isExpandedFacultyChange = false;
        private bool _isExpandedSpecialtyAdd = false;
        private bool _isExpandedSpecialtyChange = false;

        public string FacultyFullName
        {
            get { return _facultyFullName; }
            set { SetProperty(ref _facultyFullName, value); }
        }
        public string FacultyDecanFullName
        {
            get { return _facultyDecanFullName; }
            set { SetProperty(ref _facultyDecanFullName, value); }
        }
        public string FacultyPhoneDecan
        {
            get { return _facultyPhoneDecan; }
            set { SetProperty(ref _facultyPhoneDecan, value); }
        }
        public string FacultyShortName
        {
            get { return _facultyShortName; }
            set { SetProperty(ref _facultyShortName, value); }
        }
        public string SpecialtyFullName
        {
            get { return _specialtyFullName; }
            set { SetProperty(ref _specialtyFullName, value); }
        }
        public string SpecialtyShortName
        {
            get { return _specialtyShortName; }
            set { SetProperty(ref _specialtyShortName, value); }
        }
        public bool IsEnableChangeFaculty
        {
            get { return _isEnableChangeFaculty; }
            set { SetProperty(ref _isEnableChangeFaculty, value); }
        }
        public bool IsEnableChangeSpecialty
        {
            get { return _isEnableChangeSpecialty; }
            set { SetProperty(ref _isEnableChangeSpecialty, value); }
        }
        public bool IsExpandedFacultyAdd
        {
            get { return _isExpandedFacultyAdd; }
            set 
            { 
                SetProperty(ref _isExpandedFacultyAdd, value); 
            }
        }
        public bool IsExpandedFacultyChange
        {
            get { return _isExpandedFacultyChange; }
            set 
            { 
                SetProperty(ref _isExpandedFacultyChange, value); 
            }
        }
        public bool IsExpandedSpecialtyAdd
        {
            get { return _isExpandedSpecialtyAdd; }
            set 
            { 
                SetProperty(ref _isExpandedSpecialtyAdd, value); 
            }
        }
        public bool IsExpandedSpecialtyChange
        {
            get { return _isExpandedSpecialtyChange; }
            set 
            { 
                SetProperty(ref _isExpandedSpecialtyChange, value); 
            }
        }

        public DelegateCommand CloseDialogCommand { get; set; }
        public DelegateCommand<FacultyListItem> SelectedFacultyItemCommand { get; private set; }
        public DelegateCommand<SpecialtyListItem> SelectedSpecialtyItemCommand { get; private set; }
        public DelegateCommand AddFacultyCommand { get; set; }
        public DelegateCommand ChangeFacultyCommand { get; set; }
        public DelegateCommand AddSpecialtyCommand { get; set; }
        public DelegateCommand ChangeSpecialtyCommand { get; set; }
        public DialogUniversityViewModel()
        {
            Title = "Университет";
            CloseDialogCommand = new DelegateCommand(CloseDialogMethod);
            SelectedFacultyItemCommand = new DelegateCommand<FacultyListItem>(SelectedFacultyItemMethod);
            SelectedSpecialtyItemCommand = new DelegateCommand<SpecialtyListItem>(SelectedSpecialtyItemMethod);
            AddFacultyCommand = new DelegateCommand(AddFacultyMethod);
            ChangeFacultyCommand = new DelegateCommand(ChangeFacultyMethod);
            AddSpecialtyCommand = new DelegateCommand(AddSpecialtyMethod);
            ChangeSpecialtyCommand = new DelegateCommand(ChangeSpecialtyMethod);
            _itemsFaculty = new ObservableCollection<FacultyListItem>();
            _itemsSpecialty = new ObservableCollection<SpecialtyListItem>();
            AddFacultyList();
            AddSpecialtyList();
        }
        private void AddFacultyList()
        {
            _itemsFaculty.Clear();
            using (Models.DataBaseModel dataBase = new Models.DataBaseModel())
            {
                foreach(Models.DataBaseModel.Faculty faculty in dataBase.Facultys)
                {
                    _itemsFaculty.Add(new FacultyListItem
                    {
                        ID = faculty.ID,
                        Date_Create = faculty.Date_Create,
                        Full_Name = faculty.Full_Name,
                        Full_Name_Decan = faculty.Full_Name_Decan,
                        Phone_Decan = faculty.Phone_Decane,
                        Short_Name = faculty.Short_Name
                    });
                }
            }
        }
        private void AddSpecialtyList()
        {
            _itemsSpecialty.Clear();
            using (Models.DataBaseModel dataBase = new Models.DataBaseModel())
            {
                foreach (Models.DataBaseModel.Specialty specialty in dataBase.Specialtys)
                {
                    _itemsSpecialty.Add(new SpecialtyListItem
                    {
                        ID = specialty.ID,
                        Date_Create = specialty.Date_Create,
                        Full_Name = specialty.Full_Name,
                        Short_Name = specialty.Short_Name
                    });
                }
            }
        }
        private void SelectedFacultyItemMethod(FacultyListItem item)
        {
            _selectedFacultyItem = item;
            IsEnableChangeFaculty = true;
            FacultyFullName = item.Full_Name;
            FacultyDecanFullName = item.Full_Name_Decan;
            FacultyPhoneDecan = item.Phone_Decan;
            FacultyShortName = item.Short_Name;
        }
        private void SelectedSpecialtyItemMethod(SpecialtyListItem item)
        {
            _selectedSpecialtyItem = item;
            IsEnableChangeSpecialty = true;
            SpecialtyFullName = item.Full_Name;
            SpecialtyShortName = item.Short_Name;
        }
        private void AddFacultyMethod()
        {
            Models.FacultyItemDataBase.AddDataBase(new FacultyListItem {
                Full_Name = FacultyFullName,
                Full_Name_Decan = FacultyDecanFullName,
                Phone_Decan = FacultyPhoneDecan,
                Short_Name = FacultyShortName
            });
            AddFacultyList();
            MessageBox.Show("Данные сохранены в базе данных!");
        }
        private void ChangeFacultyMethod()
        {
            Models.FacultyItemDataBase.ChangeDataBase(new FacultyListItem
            {
                Full_Name = FacultyFullName,
                Full_Name_Decan = FacultyDecanFullName,
                Phone_Decan = FacultyPhoneDecan,
                Short_Name = FacultyShortName
            },_selectedFacultyItem.ID);

            AddFacultyList();
            MessageBox.Show("Данные сохранены в базе данных!");
        }
        private void AddSpecialtyMethod()
        {
            Models.SpecialtyItemDataBase.AddDataBase(new SpecialtyListItem {
                Full_Name = SpecialtyFullName,
                Short_Name = SpecialtyShortName
            });
            AddSpecialtyList();
            MessageBox.Show("Данные сохранены в базе данных!");
        }
        private void ChangeSpecialtyMethod()
        {
            Models.SpecialtyItemDataBase.ChangeDataBase(new SpecialtyListItem
            {
                Full_Name = SpecialtyFullName,
                Short_Name = SpecialtyShortName
            }, _selectedSpecialtyItem.ID);

            AddSpecialtyList();
            MessageBox.Show("Данные сохранены в базе данных!");
        }
        private void CloseDialogMethod()
        {
            RaiseRequestClose(new DialogResult(ButtonResult.Cancel));
        }
        public override void OnDialogOpened(IDialogParameters parameters)
        {
            //Message = parameters.GetValue<string>("message");
        }
        public ObservableCollection<FacultyListItem> FacultyItems
        {
            get { return _itemsFaculty; }
            set { SetProperty(ref _itemsFaculty, value); }
        }
        public ObservableCollection<SpecialtyListItem> SpecialtyItems
        {
            get { return _itemsSpecialty; }
            set { SetProperty(ref _itemsSpecialty, value); }
        }
    }
    internal class FacultyListItem
    {
        public int ID { get; set; }
        public DateTime Date_Create { get; set; }
        public string? Full_Name { get; set; }
        public string? Full_Name_Decan { get; set; }
        public string? Phone_Decan { get; set; }
        public string? Short_Name { get; set; }
    }
    internal class SpecialtyListItem
    {
        public int ID { get; set; }
        public DateTime Date_Create { get; set; }
        public string? Full_Name { get; set; }
        public string? Short_Name { get; set; }
    }
}
