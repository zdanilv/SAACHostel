using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using SAACHostel.Models;

namespace SAACHostel.ViewModels
{
    internal class HostelItemListViewModel : BindableBase
    {
        IEventAggregator _eventAggregator;
        private int _order;
        private bool _exact = false;
        private string _findParameter;
        private ObservableCollection<HostelListItem> _items;
        private List<HostelSortItem> _hostelSortItems;
        private HostelSortItem _selectedHostelSortItems;
        private List<HostelFindItem> _hostelFindItems;
        private HostelFindItem _selectedHostelFindItems;
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
        public HostelSortItem SelectedHostelSortItems
        {
            get { return _selectedHostelSortItems; }
            set { SetProperty(ref _selectedHostelSortItems, value); SortedList(); }
        }
        public HostelFindItem SelectedHostelFindItems
        {
            get { return _selectedHostelFindItems; }
            set { SetProperty(ref _selectedHostelFindItems, value); }
        }
        public DelegateCommand SelectedOrderByCommand { get; private set; }
        public DelegateCommand SelectedOrderByDescendingCommand { get; private set; }
        public DelegateCommand FindCommand { get; private set; }
        public DelegateCommand UpdateListCommand { get; private set; }
        public DelegateCommand<HostelListItem> SelectedItemCommand { get; private set; }
        public HostelItemListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<Events.HostelListUpdateEvent>().Subscribe(UpdateList);

            SelectedItemCommand = new DelegateCommand<HostelListItem>(SelectedItemMethod);
            SelectedOrderByCommand = new DelegateCommand(SelectedOrderByMethod);
            SelectedOrderByDescendingCommand = new DelegateCommand(SelectedOrderByDescendingMethod);
            FindCommand = new DelegateCommand(FindMethod);
            UpdateListCommand = new DelegateCommand(UpdateList);
            _items = new ObservableCollection<HostelListItem>();
            _hostelSortItems = new List<HostelSortItem>();
            _hostelFindItems = new List<HostelFindItem>();
            AddHostelSortItem();
            AddHostelFindItem();
            UpdateList();
        }
        private void AddHostelSortItem()
        {
            _hostelSortItems.Add(new HostelSortItem { ID = 0, Name = "Номер" });
            _hostelSortItems.Add(new HostelSortItem { ID = 1, Name = "Дата создания" });
            _hostelSortItems.Add(new HostelSortItem { ID = 2, Name = "Количество комнат" });
        }
        private void AddHostelFindItem()
        {
            _hostelFindItems.Add(new HostelFindItem { ID = 0, Name = "Номер" });
            _hostelFindItems.Add(new HostelFindItem { ID = 1, Name = "Дата создания" });
            _hostelFindItems.Add(new HostelFindItem { ID = 2, Name = "Количество комнат" });
        }
        private void UpdateList()
        {
            _items.Clear();
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.Hostel hostel in dataBase.Hostels)
                {
                    _items.Add(new HostelListItem()
                    {
                        ID = hostel.ID,
                        Date_Create = hostel.Date_Create,
                        Count_Rooms = hostel.Count_Room,
                        Phone = hostel.Phone
                    });
                }
            }
        }
        private void SortedList()
        {
            if(_selectedHostelSortItems != null)
            {
                if (_selectedHostelSortItems.ID == 0)
                    if (Order == 0)
                        Items = new ObservableCollection<HostelListItem>(_items.OrderBy(i => i.ID));
                    else Items = new ObservableCollection<HostelListItem>(_items.OrderByDescending(i => i.ID));

                if (_selectedHostelSortItems.ID == 1)
                    if (Order == 0)
                        Items = new ObservableCollection<HostelListItem>(_items.OrderBy(i => i.Date_Create));
                    else Items = new ObservableCollection<HostelListItem>(_items.OrderByDescending(i => i.Date_Create));

                if (_selectedHostelSortItems.ID == 2)
                    if (Order == 0)
                        Items = new ObservableCollection<HostelListItem>(_items.OrderBy(i => i.Count_Rooms));
                    else Items = new ObservableCollection<HostelListItem>(_items.OrderByDescending(i => i.Count_Rooms));
            }
        }
        private void FindMethod()
        {
            if (_selectedHostelFindItems != null)
            {
                UpdateList();
                if (Exact)
                {
                    if (_selectedHostelFindItems.ID == 0)
                    {
                        Items = new ObservableCollection<HostelListItem>(_items.Where(i => i.ID == Int32.Parse(FindParameter)));
                    }
                    if (_selectedHostelFindItems.ID == 1)
                    {
                        Items = new ObservableCollection<HostelListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                    if (_selectedHostelFindItems.ID == 2)
                    {
                        Items = new ObservableCollection<HostelListItem>(_items.Where(i => i.Count_Rooms == Int32.Parse(FindParameter)));
                    }
                }
                else
                {
                    if (_selectedHostelFindItems.ID == 0)
                    {
                        Items = new ObservableCollection<HostelListItem>(_items.Where(i => i.ID.ToString().Contains(FindParameter)));
                    }
                    if (_selectedHostelFindItems.ID == 1)
                    {
                        if (FindParameter.Length == 2)
                            Items = new ObservableCollection<HostelListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd", CultureInfo.InvariantCulture)));
                        if (FindParameter.Length == 5)
                            Items = new ObservableCollection<HostelListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd.MM", CultureInfo.InvariantCulture)));
                        if (FindParameter.Length == 10)
                            Items = new ObservableCollection<HostelListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                    if (_selectedHostelFindItems.ID == 4)
                    {
                        Items = new ObservableCollection<HostelListItem>(_items.Where(i => i.Count_Rooms.ToString().Contains(FindParameter)));
                    }
                }
            }

        }
        public List<HostelSortItem> HostelSortItems
        {
            get { return _hostelSortItems; }
        }
        public ObservableCollection<HostelListItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        private void SelectedOrderByMethod()
        {
            Order = 0; SortedList();
        }
        private void SelectedOrderByDescendingMethod()
        {
            Order = 1; SortedList();
        }
        private void SelectedItemMethod(HostelListItem item)
        {
            _eventAggregator.GetEvent<Events.HostelOpenItemEvent>().Publish(item.ID); //<Setter Property="NewItemFactory" Value="{x:Static localModels:TabNewItem.Factory}" 
        }
    }
    internal class HostelListItem
    {
        public int ID { get; set; }
        public DateTime Date_Create { get; set; }
        public int Count_Rooms { get; set; }
        public string? Phone { get; set; }
    }
    internal class HostelSortItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    internal class HostelFindItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
