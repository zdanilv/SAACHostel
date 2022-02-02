using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using SAACHostel.Models;

namespace SAACHostel.ViewModels
{
    internal class StudentItemListViewModel : BindableBase
    {
        IEventAggregator _eventAggregator;
        private int _order;
        private bool _exact = false;
        private string _findParameter;
        private ObservableCollection<StudentListItem> _items;
        private List<StudentSortItem> _studentSortItems;
        private StudentSortItem _selectedStudentSortItems;
        private List<StudentFindItem> _studentFindItems;
        private StudentFindItem _selectedStudentFindItems;
        public int Order
        {
            get { return _order; }
            set { SetProperty(ref _order, value); }
        }
        public bool Exact
        {
            get { return _exact; }
            set { SetProperty(ref _exact, value); }
        }
        public string FindParameter
        {
            get { return _findParameter; }
            set { SetProperty(ref _findParameter, value); }
        }
        public StudentSortItem SelectedStudentSortItems
        {
            get { return _selectedStudentSortItems; }
            set { SetProperty(ref _selectedStudentSortItems, value); SortedList(); }
        }
        public StudentFindItem SelectedStudentFindItems
        {
            get { return _selectedStudentFindItems; }
            set { SetProperty(ref _selectedStudentFindItems, value); }
        }
        public DelegateCommand SelectedOrderByCommand { get; private set; }
        public DelegateCommand SelectedOrderByDescendingCommand { get; private set; }
        public DelegateCommand FindCommand { get; private set; }
        public DelegateCommand UpdateListCommand { get; private set; }
        public DelegateCommand<StudentListItem> SelectedItemCommand { get; private set; }
        public StudentItemListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<Events.StudentListUpdateEvent>().Subscribe(UpdateList);

            SelectedItemCommand = new DelegateCommand<StudentListItem>(SelectedItemMethod);
            SelectedOrderByCommand = new DelegateCommand(SelectedOrderByMethod);
            SelectedOrderByDescendingCommand = new DelegateCommand(SelectedOrderByDescendingMethod);
            FindCommand = new DelegateCommand(FindMethod);
            UpdateListCommand = new DelegateCommand(UpdateList);
            _items = new ObservableCollection<StudentListItem>();
            _studentSortItems = new List<StudentSortItem>();
            _studentFindItems = new List<StudentFindItem>();
            AddStudentSortItem();
            AddStudentFindItem();
            UpdateList();
        }
        private void AddStudentSortItem()
        {
            _studentSortItems.Add(new StudentSortItem { ID = 0, Name = "Номер" });
            _studentSortItems.Add(new StudentSortItem { ID = 1, Name = "Дата создания" });
            _studentSortItems.Add(new StudentSortItem { ID = 2, Name = "Имя" });
            _studentSortItems.Add(new StudentSortItem { ID = 3, Name = "Фамилия" });
            _studentSortItems.Add(new StudentSortItem { ID = 4, Name = "Отчество" });
            _studentSortItems.Add(new StudentSortItem { ID = 5, Name = "Факультет" });
            _studentSortItems.Add(new StudentSortItem { ID = 6, Name = "Специальность" });
            _studentSortItems.Add(new StudentSortItem { ID = 7, Name = "Группа" });
        }
        private void AddStudentFindItem()
        {
            _studentFindItems.Add(new StudentFindItem { ID = 0, Name = "Номер" });
            _studentFindItems.Add(new StudentFindItem { ID = 1, Name = "Дата создания" });
            _studentFindItems.Add(new StudentFindItem { ID = 2, Name = "Имя" });
            _studentFindItems.Add(new StudentFindItem { ID = 3, Name = "Фамилия" });
            _studentFindItems.Add(new StudentFindItem { ID = 4, Name = "Отчество" });
            _studentFindItems.Add(new StudentFindItem { ID = 5, Name = "Факультет" });
            _studentFindItems.Add(new StudentFindItem { ID = 6, Name = "Специальность" });
            _studentFindItems.Add(new StudentFindItem { ID = 7, Name = "Группа" });
        }
        private void UpdateList()
        {
            _items.Clear();
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.Student student in dataBase.Students)
                {
                    _items.Add(new StudentListItem()
                    {
                        ID = student.ID,
                        Date_Create = student.Date_Create,
                        Student_FirstName = student.First_Name,
                        Student_LastName = student.Last_Name,
                        Student_MiddleName = student.Middle_Name,
                        Faculty_ID = student.FacultyID,
                        Specialty_ID = student.SpecialtyID,
                        Group = student.Group
                    });
                }
            }
        }
        private void SortedList()
        {
            if (_selectedStudentSortItems != null)
            {
                if (_selectedStudentSortItems.ID == 0)
                    if (Order == 0)
                        Items = new ObservableCollection<StudentListItem>(_items.OrderBy(i => i.ID));
                    else Items = new ObservableCollection<StudentListItem>(_items.OrderByDescending(i => i.ID));

                if (_selectedStudentSortItems.ID == 1)
                    if (Order == 0)
                        Items = new ObservableCollection<StudentListItem>(_items.OrderBy(i => i.Date_Create));
                    else Items = new ObservableCollection<StudentListItem>(_items.OrderByDescending(i => i.Date_Create));

                if (_selectedStudentSortItems.ID == 2)
                    if (Order == 0)
                        Items = new ObservableCollection<StudentListItem>(_items.OrderBy(i => i.Student_FirstName));
                    else Items = new ObservableCollection<StudentListItem>(_items.OrderByDescending(i => i.Student_FirstName));

                if (_selectedStudentSortItems.ID == 3)
                    if (Order == 0)
                        Items = new ObservableCollection<StudentListItem>(_items.OrderBy(i => i.Student_LastName));
                    else Items = new ObservableCollection<StudentListItem>(_items.OrderByDescending(i => i.Student_LastName));

                if (_selectedStudentSortItems.ID == 4)
                    if (Order == 0)
                        Items = new ObservableCollection<StudentListItem>(_items.OrderBy(i => i.Student_MiddleName));
                    else Items = new ObservableCollection<StudentListItem>(_items.OrderByDescending(i => i.Student_MiddleName));

                if (_selectedStudentSortItems.ID == 5)
                    if (Order == 0)
                        Items = new ObservableCollection<StudentListItem>(_items.OrderBy(i => i.Faculty_ID));
                    else Items = new ObservableCollection<StudentListItem>(_items.OrderByDescending(i => i.Faculty_ID));

                if (_selectedStudentSortItems.ID == 6)
                    if (Order == 0)
                        Items = new ObservableCollection<StudentListItem>(_items.OrderBy(i => i.Specialty_ID));
                    else Items = new ObservableCollection<StudentListItem>(_items.OrderByDescending(i => i.Specialty_ID));

                if (_selectedStudentSortItems.ID == 7)
                    if (Order == 0)
                        Items = new ObservableCollection<StudentListItem>(_items.OrderBy(i => i.Group));
                    else Items = new ObservableCollection<StudentListItem>(_items.OrderByDescending(i => i.Group));
            }
        }
        private void FindMethod()
        {
            if (_selectedStudentFindItems != null)
            {
                UpdateList();
                if (Exact)
                {
                    if (_selectedStudentFindItems.ID == 0)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.ID == Int32.Parse(FindParameter)));
                    }
                    if (_selectedStudentFindItems.ID == 1)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                    if (_selectedStudentFindItems.ID == 2)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Student_FirstName == FindParameter));
                    }
                    if (_selectedStudentFindItems.ID == 3)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Student_LastName == FindParameter));
                    }
                    if (_selectedStudentFindItems.ID == 4)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Student_MiddleName == FindParameter));
                    }
                    if (_selectedStudentFindItems.ID == 5)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Faculty_ID == Int32.Parse(FindParameter)));
                    }
                    if (_selectedStudentFindItems.ID == 6)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Specialty_ID == Int32.Parse(FindParameter)));
                    }
                    if (_selectedStudentFindItems.ID == 7)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Group == FindParameter));
                    }
                }
                else
                {
                    if (_selectedStudentFindItems.ID == 0)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.ID.ToString().Contains(FindParameter)));
                    }
                    if (_selectedStudentFindItems.ID == 1)
                    {
                        if (FindParameter.Length == 2)
                            Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd", CultureInfo.InvariantCulture)));
                        if (FindParameter.Length == 5)
                            Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd.MM", CultureInfo.InvariantCulture)));
                        if (FindParameter.Length == 10)
                            Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                    if (_selectedStudentFindItems.ID == 2)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Student_FirstName.Contains(FindParameter)));
                    }
                    if (_selectedStudentFindItems.ID == 3)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Student_LastName.Contains(FindParameter)));
                    }
                    if (_selectedStudentFindItems.ID == 4)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Student_MiddleName.Contains(FindParameter)));
                    }
                    if (_selectedStudentFindItems.ID == 5)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Faculty_ID.ToString().Contains(FindParameter)));
                    }
                    if (_selectedStudentFindItems.ID == 6)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Specialty_ID.ToString().Contains(FindParameter)));
                    }
                    if (_selectedStudentFindItems.ID == 7)
                    {
                        Items = new ObservableCollection<StudentListItem>(_items.Where(i => i.Group.Contains(FindParameter)));
                    }
                }
            }

        }
        private void SelectedOrderByMethod()
        {
            Order = 0; SortedList();
        }
        private void SelectedOrderByDescendingMethod()
        {
            Order = 1; SortedList();
        }
        public List<StudentSortItem> StudentSortItems
        {
            get { return _studentSortItems; }
        }
        public List<StudentFindItem> StudentFindItems
        {
            get { return _studentFindItems; }
        }
        public ObservableCollection<StudentListItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        private void SelectedItemMethod(StudentListItem item)
        {
            _eventAggregator.GetEvent<Events.StudentOpenItemEvent>().Publish(item.ID); //<Setter Property="NewItemFactory" Value="{x:Static localModels:TabNewItem.Factory}" 
        }
    }
    internal class StudentListItem
    {
        public int ID { get; set; }
        public DateTime Date_Create { get; set; }
        public string? Student_FirstName { get; set; }
        public string? Student_LastName { get; set; }
        public string? Student_MiddleName { get; set; }
        public int Faculty_ID { get; set; }
        public int Specialty_ID { get; set; }
        public string? Group { get; set; }
    }
    internal class StudentSortItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    internal class StudentFindItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

