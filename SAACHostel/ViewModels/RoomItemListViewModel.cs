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
    internal class RoomItemListViewModel : BindableBase
    {
        IEventAggregator _eventAggregator;
        private int _order;
        private bool _exact = false;
        private string _findParameter;
        private ObservableCollection<RoomListItem> _items;
        private List<RoomSortItem> _roomSortItems;
        private RoomSortItem _selectedRoomSortItems;
        private List<RoomFindItem> _roomFindItems;
        private RoomFindItem _selectedRoomFindItems;
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
        public RoomSortItem SelectedRoomSortItems
        {
            get { return _selectedRoomSortItems; }
            set { SetProperty(ref _selectedRoomSortItems, value); SortedList(); }
        }
        public RoomFindItem SelectedRoomFindItems
        {
            get { return _selectedRoomFindItems; }
            set { SetProperty(ref _selectedRoomFindItems, value); }
        }
        public DelegateCommand SelectedOrderByCommand { get; private set; }
        public DelegateCommand SelectedOrderByDescendingCommand { get; private set; }
        public DelegateCommand FindCommand { get; private set; }
        public DelegateCommand UpdateListCommand { get; private set; }
        public DelegateCommand<RoomListItem> SelectedItemCommand { get; private set; }
        public RoomItemListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<Events.RoomListUpdateEvent>().Subscribe(UpdateList);

            SelectedItemCommand = new DelegateCommand<RoomListItem>(SelectedItemMethod);
            SelectedOrderByCommand = new DelegateCommand(SelectedOrderByMethod);
            SelectedOrderByDescendingCommand = new DelegateCommand(SelectedOrderByDescendingMethod);
            FindCommand = new DelegateCommand(FindMethod);
            UpdateListCommand = new DelegateCommand(UpdateList);
            _items = new ObservableCollection<RoomListItem>();
            _roomSortItems = new List<RoomSortItem>();
            _roomFindItems = new List<RoomFindItem>();
            AddRoomSortItem();
            AddRoomFindItem();
            UpdateList();
        }
        private void AddRoomSortItem()
        {
            _roomSortItems.Add(new RoomSortItem { ID = 0, Name = "Номер" });
            _roomSortItems.Add(new RoomSortItem { ID = 1, Name = "Дата создания" });
            _roomSortItems.Add(new RoomSortItem { ID = 2, Name = "Количество мест" });
            _roomSortItems.Add(new RoomSortItem { ID = 3, Name = "Номер общежития" });
        }
        private void AddRoomFindItem()
        {
            _roomFindItems.Add(new RoomFindItem { ID = 0, Name = "Номер" });
            _roomFindItems.Add(new RoomFindItem { ID = 1, Name = "Дата создания" });
            _roomFindItems.Add(new RoomFindItem { ID = 2, Name = "Количество мест" });
            _roomSortItems.Add(new RoomSortItem { ID = 3, Name = "Номер общежития" });
        }
        private void UpdateList()
        {
            _items.Clear();
            using (DataBaseModel dataBase = new DataBaseModel())
            {
                foreach (DataBaseModel.Room room in dataBase.Rooms)
                {
                    _items.Add(new RoomListItem()
                    {
                        ID = room.ID,
                        Date_Create = room.Date_Create,
                        Capacity = room.Capacity,
                        HostelID = room.HostelID,
                    });
                }
            }
        }
        private void SortedList()
        {
            if (_selectedRoomSortItems != null)
            {
                if (_selectedRoomSortItems.ID == 0)
                    if (Order == 0)
                        Items = new ObservableCollection<RoomListItem>(_items.OrderBy(i => i.ID));
                    else Items = new ObservableCollection<RoomListItem>(_items.OrderByDescending(i => i.ID));

                if (_selectedRoomSortItems.ID == 1)
                    if (Order == 0)
                        Items = new ObservableCollection<RoomListItem>(_items.OrderBy(i => i.Date_Create));
                    else Items = new ObservableCollection<RoomListItem>(_items.OrderByDescending(i => i.Date_Create));

                if (_selectedRoomSortItems.ID == 2)
                    if (Order == 0)
                        Items = new ObservableCollection<RoomListItem>(_items.OrderBy(i => i.Capacity));
                    else Items = new ObservableCollection<RoomListItem>(_items.OrderByDescending(i => i.Capacity));
                if (_selectedRoomSortItems.ID == 3)
                    if (Order == 0)
                        Items = new ObservableCollection<RoomListItem>(_items.OrderBy(i => i.HostelID));
                    else Items = new ObservableCollection<RoomListItem>(_items.OrderByDescending(i => i.HostelID));
            }
        }
        private void FindMethod()
        {
            if (_selectedRoomFindItems != null)
            {
                UpdateList();
                if (Exact)
                {
                    if (_selectedRoomFindItems.ID == 0)
                    {
                        Items = new ObservableCollection<RoomListItem>(_items.Where(i => i.ID == Int32.Parse(FindParameter)));
                    }
                    if (_selectedRoomFindItems.ID == 1)
                    {
                        Items = new ObservableCollection<RoomListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                    if (_selectedRoomFindItems.ID == 2)
                    {
                        Items = new ObservableCollection<RoomListItem>(_items.Where(i => i.Capacity == Int32.Parse(FindParameter)));
                    }
                    if (_selectedRoomFindItems.ID == 2)
                    {
                        Items = new ObservableCollection<RoomListItem>(_items.Where(i => i.HostelID == Int32.Parse(FindParameter)));
                    }
                }
                else
                {
                    if (_selectedRoomFindItems.ID == 0)
                    {
                        Items = new ObservableCollection<RoomListItem>(_items.Where(i => i.ID.ToString().Contains(FindParameter)));
                    }
                    if (_selectedRoomFindItems.ID == 1)
                    {
                        if (FindParameter.Length == 2)
                            Items = new ObservableCollection<RoomListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd", CultureInfo.InvariantCulture)));
                        if (FindParameter.Length == 5)
                            Items = new ObservableCollection<RoomListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd.MM", CultureInfo.InvariantCulture)));
                        if (FindParameter.Length == 10)
                            Items = new ObservableCollection<RoomListItem>(_items.Where(i => i.Date_Create == DateTime.ParseExact(FindParameter, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                    if (_selectedRoomFindItems.ID == 2)
                    {
                        Items = new ObservableCollection<RoomListItem>(_items.Where(i => i.Capacity.ToString().Contains(FindParameter)));
                    }
                    if (_selectedRoomFindItems.ID == 3)
                    {
                        Items = new ObservableCollection<RoomListItem>(_items.Where(i => i.HostelID.ToString().Contains(FindParameter)));
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
        public List<RoomSortItem> RoomSortItems
        {
            get { return _roomSortItems; }
        }
        public List<RoomFindItem> RoomFindItems
        {
            get { return _roomFindItems; }
        }
        public ObservableCollection<RoomListItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        private void SelectedItemMethod(RoomListItem item)
        {
            _eventAggregator.GetEvent<Events.RoomOpenItemEvent>().Publish(item.ID); //<Setter Property="NewItemFactory" Value="{x:Static localModels:TabNewItem.Factory}" 
        }
    }
    internal class RoomListItem
    {
        public int ID { get; set; }
        public DateTime Date_Create { get; set; }
        public int Capacity { get; set; }
        public int HostelID { get; set; }
    }
    internal class RoomSortItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    internal class RoomFindItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
