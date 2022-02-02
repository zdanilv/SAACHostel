using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using SAACHostel.Models;

namespace SAACHostel.ViewModels
{
    internal class JournalItemListViewModel : BindableBase
    {
        IEventAggregator _eventAggregator;
        private int _order;
        private bool _exact = false;
        private string _findParameter;
        private ObservableCollection<LogEntryListItem> _items;
        private List<JournalSortItem> _journalSortItems;
        private JournalSortItem _selectedJournalSortItems;
        private List<JournalFindItem> _journalFindItems;
        private JournalFindItem _selectedJournalFindItems;
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
        public JournalSortItem SelectedJournalSortItems
        {
            get { return _selectedJournalSortItems; }
            set { SetProperty(ref _selectedJournalSortItems, value); SortedList(); }
        }
        public JournalFindItem SelectedJournalFindItems
        {
            get { return _selectedJournalFindItems; }
            set { SetProperty(ref _selectedJournalFindItems, value); }
        }
        public DelegateCommand SelectedOrderByCommand { get; private set; }
        public DelegateCommand SelectedOrderByDescendingCommand { get; private set; }
        public DelegateCommand FindCommand { get; private set; }
        public DelegateCommand UpdateListCommand { get; private set; }
        public DelegateCommand<LogEntryListItem> SelectedItemCommand { get; private set; }
        public JournalItemListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<Events.JournalListUpdateEvent>().Subscribe(UpdateList);

            SelectedItemCommand = new DelegateCommand<LogEntryListItem>(SelectedItemMethod);
            SelectedOrderByCommand = new DelegateCommand(SelectedOrderByMethod);
            SelectedOrderByDescendingCommand = new DelegateCommand(SelectedOrderByDescendingMethod);
            FindCommand = new DelegateCommand(FindMethod);
            UpdateListCommand = new DelegateCommand(UpdateList);
            _items = new ObservableCollection<LogEntryListItem>();
            _journalSortItems = new List<JournalSortItem>();
            _journalFindItems = new List<JournalFindItem>();
            AddJournalSortItem();
            AddJournalFindItem();
            UpdateList();
        }
        private void AddJournalSortItem()
        {
            _journalSortItems.Add(new JournalSortItem { ID = 0, Name = "Номер" });
            _journalSortItems.Add(new JournalSortItem { ID = 1, Name = "Дата создания" });
            _journalSortItems.Add(new JournalSortItem { ID = 2, Name = "Контрагент" });
            _journalSortItems.Add(new JournalSortItem { ID = 3, Name = "Студент" });
            _journalSortItems.Add(new JournalSortItem { ID = 4, Name = "Комната" });
            _journalSortItems.Add(new JournalSortItem { ID = 5, Name = "Общежитие" });
            _journalSortItems.Add(new JournalSortItem { ID = 6, Name = "Статус" });
        }
        private void AddJournalFindItem()
        {
            _journalFindItems.Add(new JournalFindItem { ID = 0, Name = "Номер" });
            _journalFindItems.Add(new JournalFindItem { ID = 1, Name = "Дата создания" });
            _journalFindItems.Add(new JournalFindItem { ID = 2, Name = "Дата заселения" });
            _journalFindItems.Add(new JournalFindItem { ID = 3, Name = "Дата выселения" });
            _journalFindItems.Add(new JournalFindItem { ID = 4, Name = "Контрагент" });
            _journalFindItems.Add(new JournalFindItem { ID = 5, Name = "Студент" });
            _journalFindItems.Add(new JournalFindItem { ID = 6, Name = "Комната" });
            _journalFindItems.Add(new JournalFindItem { ID = 7, Name = "Общежитие" });
        }
        private void UpdateList()
        {
            _items.Clear();
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.LogEntry logEntry in dataBase.LogEntrys)
                {
                    LogEntryListItem logEntryListItem = new LogEntryListItem()
                    {
                        ID = logEntry.ID,
                        Date_Create = logEntry.Date_Create,
                        Room_ID = logEntry.RoomID,
                        Hostel_ID = logEntry.HostelID,
                        Date_Ent = logEntry.Date_Ent,
                        Date_Ext = logEntry.Date_Ext
                    };
                    foreach (DataBaseModel.User user in dataBase.Users)
                    {
                        if (user.ID == logEntry.UserID)
                            logEntryListItem.User_ShortName = String.Join(". ", new string[] { user.First_Name.FirstOrDefault().ToString(), user.Last_Name.FirstOrDefault().ToString(), user.Middle_Name });
                    }
                    foreach (DataBaseModel.Student student in dataBase.Students)
                    {
                        if (student.ID == logEntry.StudentID)
                            logEntryListItem.Student_FullName = String.Join(" ", new string[] { student.First_Name, student.Last_Name, student.Middle_Name });
                    }
                    if (logEntry.State)
                        logEntryListItem.State = "Оплачено";
                    else logEntryListItem.State = "Не оплачено";
                    _items.Add(logEntryListItem);
                }
            }
        }
        private void SortedList()
        {
            if (_selectedJournalSortItems != null)
            {
                if (_selectedJournalSortItems.ID == 0)
                    if (Order == 0)
                        Items = new ObservableCollection<LogEntryListItem>(_items.OrderBy(i => i.ID));
                    else Items = new ObservableCollection<LogEntryListItem>(_items.OrderByDescending(i => i.ID));

                if (_selectedJournalSortItems.ID == 1)
                    if (Order == 0)
                        Items = new ObservableCollection<LogEntryListItem>(_items.OrderBy(i => i.Date_Create));
                    else Items = new ObservableCollection<LogEntryListItem>(_items.OrderByDescending(i => i.Date_Create));

                if (_selectedJournalSortItems.ID == 2)
                    if (Order == 0)
                        Items = new ObservableCollection<LogEntryListItem>(_items.OrderBy(i => i.User_ShortName));
                    else Items = new ObservableCollection<LogEntryListItem>(_items.OrderByDescending(i => i.User_ShortName));

                if (_selectedJournalSortItems.ID == 3)
                    if (Order == 0)
                        Items = new ObservableCollection<LogEntryListItem>(_items.OrderBy(i => i.Student_FullName));
                    else Items = new ObservableCollection<LogEntryListItem>(_items.OrderByDescending(i => i.Student_FullName));

                if (_selectedJournalSortItems.ID == 4)
                    if (Order == 0)
                        Items = new ObservableCollection<LogEntryListItem>(_items.OrderBy(i => i.Room_ID));
                    else Items = new ObservableCollection<LogEntryListItem>(_items.OrderByDescending(i => i.Room_ID));

                if (_selectedJournalSortItems.ID == 5)
                    if (Order == 0)
                        Items = new ObservableCollection<LogEntryListItem>(_items.OrderBy(i => i.Hostel_ID));
                    else Items = new ObservableCollection<LogEntryListItem>(_items.OrderByDescending(i => i.Hostel_ID));

                if (_selectedJournalSortItems.ID == 6)
                    if (Order == 0)
                        Items = new ObservableCollection<LogEntryListItem>(_items.OrderBy(i => i.State));
                    else Items = new ObservableCollection<LogEntryListItem>(_items.OrderByDescending(i => i.State));
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
        private void FindMethod()
        {
            if (_selectedJournalFindItems != null)
            {
                UpdateList();
                if (Exact)
                {
                    if(_selectedJournalFindItems.ID == 0)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.ID == Int32.Parse(FindParameter)));
                    }
                    if (_selectedJournalFindItems.ID == 1)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                    if (_selectedJournalFindItems.ID == 2)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Date_Ent == DateTime.ParseExact(FindParameter, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                    if (_selectedJournalFindItems.ID == 3)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Date_Ext == DateTime.ParseExact(FindParameter, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                    if (_selectedJournalFindItems.ID == 4)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.User_ShortName == FindParameter));
                    }
                    if (_selectedJournalFindItems.ID == 5)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Student_FullName == FindParameter));
                    }
                    if (_selectedJournalFindItems.ID == 6)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Room_ID == Int32.Parse(FindParameter)));
                    }
                    if (_selectedJournalFindItems.ID == 7)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Hostel_ID == Int32.Parse(FindParameter)));
                    }
                }
                else
                {
                    if (_selectedJournalFindItems.ID == 0)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.ID.ToString().Contains(FindParameter)));
                    }
                    if (_selectedJournalFindItems.ID == 1)
                    {
                        if(FindParameter.Length == 2)
                            Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd", CultureInfo.InvariantCulture)));
                        if(FindParameter.Length == 5)
                            Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd.MM", CultureInfo.InvariantCulture)));
                        if(FindParameter.Length == 10)
                            Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                    if (_selectedJournalFindItems.ID == 2)
                    {
                        if (FindParameter.Length == 2)
                            Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Date_Ent == DateTime.ParseExact(FindParameter, "dd", CultureInfo.InvariantCulture)));
                        if (FindParameter.Length == 5)
                            Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Date_Ent == DateTime.ParseExact(FindParameter, "dd.MM", CultureInfo.InvariantCulture)));
                        if (FindParameter.Length == 10)
                            Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Date_Ent == DateTime.ParseExact(FindParameter, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                    if (_selectedJournalFindItems.ID == 3)
                    {
                        if (FindParameter.Length == 2)
                            Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Date_Ext == DateTime.ParseExact(FindParameter, "dd", CultureInfo.InvariantCulture)));
                        if (FindParameter.Length == 5)
                            Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Date_Ext == DateTime.ParseExact(FindParameter, "dd.MM", CultureInfo.InvariantCulture)));
                        if (FindParameter.Length == 10)
                            Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Date_Ext == DateTime.ParseExact(FindParameter, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                    if (_selectedJournalFindItems.ID == 4)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.User_ShortName.Contains(FindParameter)));
                    }
                    if (_selectedJournalFindItems.ID == 5)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Student_FullName.Contains(FindParameter)));
                    }
                    if (_selectedJournalFindItems.ID == 6)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Room_ID.ToString().Contains(FindParameter)));
                    }
                    if (_selectedJournalFindItems.ID == 7)
                    {
                        Items = new ObservableCollection<LogEntryListItem>(_items.Where(i => i.Hostel_ID.ToString().Contains(FindParameter)));
                    }
                }
            }

        }
        public List<JournalSortItem> JournalSortItems
        {
            get { return _journalSortItems; }
        }
        public List<JournalFindItem> JournalFindItems
        {
            get { return _journalFindItems; }
        }
        public ObservableCollection<LogEntryListItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        private void SelectedItemMethod(LogEntryListItem item)
        {
            _eventAggregator.GetEvent<Events.JournalOpenItemEvent>().Publish(item.ID); //<Setter Property="NewItemFactory" Value="{x:Static localModels:TabNewItem.Factory}" 
        }
    }
    internal class LogEntryListItem
    {
        public int ID { get; set; }
        public DateTime Date_Create { get; set; }
        public string? User_ShortName { get; set; }
        public int Room_ID { get; set; }
        public string? Student_FullName { get; set; }
        public int Hostel_ID { get; set; }
        public DateTime Date_Ent { get; set; }
        public DateTime Date_Ext { get; set; }
        public int Pay { get; set; }
        public string State { get; set; }
    }
    internal class JournalSortItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    internal class JournalFindItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
