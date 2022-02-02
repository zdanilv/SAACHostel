using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dragablz;
using Dragablz.Dockablz;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;

namespace SAACHostel.ViewModels
{
    internal class HostelViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        public DelegateCommand LoadData { get; private set; }
        public DelegateCommand HostelListAddCommand { get; set; }
        public DelegateCommand HostelAddCommand { get; set; }
        private bool _isStarted = false;

        private readonly ObservableCollection<HeaderedItemViewModel> _items;
        private readonly ObservableCollection<HeaderedItemViewModel> _toolItems = new ObservableCollection<HeaderedItemViewModel>();
        public HostelViewModel()
        {
            _items = new ObservableCollection<HeaderedItemViewModel>();
        }
        public HostelViewModel(IEventAggregator eventAggregator, params HeaderedItemViewModel[] items)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<Events.HostelOpenItemEvent>().Subscribe(HostelOpenMethod);

            LoadData = new DelegateCommand(StartViewMethod);
            HostelListAddCommand = new DelegateCommand(HostelListAddMethod);
            HostelAddCommand = new DelegateCommand(HostelAddMethod);

            _items = new ObservableCollection<HeaderedItemViewModel>(items);
            _items.RemoveAt(0);
        }
        private void StartViewMethod()
        {
            if (!_isStarted)
            {
                HostelListAddMethod();
                _isStarted = true;
            }
        }

        private void HostelListAddMethod()
        {
            _items.Add(new HeaderedItemViewModel { Header = "Список записей", Content = new Views.HostelItemListView() });
        }
        private void HostelAddMethod()
        {
            _items.Add(new HeaderedItemViewModel { Header = "Новая запись", Content = new Views.HostelItemInfoAdvancedView() { DataContext = Models.HostelItemOpenAddDataBase.GetViewModel(-1, _eventAggregator) } });
        }
        private void HostelOpenMethod(int id)
        {
            _items.Add(new HeaderedItemViewModel { Header = "Текущая запись", Content = new Views.HostelItemInfoAdvancedView() { DataContext = Models.HostelItemOpenAddDataBase.GetViewModel(id, _eventAggregator) } });
        }
        public ObservableCollection<HeaderedItemViewModel> Items
        {
            get { return _items; }
        }

        public static Guid TabPartition
        {
            get { return new Guid("2AE89D18-F236-4D20-9605-6C03319038E6"); }
        }

        public ObservableCollection<HeaderedItemViewModel> ToolItems
        {
            get { return _toolItems; }
        }

        public ItemActionCallback ClosingTabItemHandler
        {
            get { return ClosingTabItemHandlerImpl; }
        }

        /// <summary>
        /// Callback to handle tab closing.
        /// </summary>        
        private static void ClosingTabItemHandlerImpl(ItemActionCallbackArgs<TabablzControl> args)
        {
            //in here you can dispose stuff or cancel the close

            //here's your view model:
            var viewModel = args.DragablzItem.DataContext as HeaderedItemViewModel;
            Debug.Assert(viewModel != null);

            //here's how you can cancel stuff:
            //args.Cancel(); 
        }

        public ClosingFloatingItemCallback ClosingFloatingItemHandler
        {
            get { return ClosingFloatingItemHandlerImpl; }
        }

        private static void ClosingFloatingItemHandlerImpl(ItemActionCallbackArgs<Layout> args)
        {
            //in here you can dispose stuff or cancel the close

            //here's your view model: 
            var disposable = args.DragablzItem.DataContext as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            //here's how you can cancel stuff:
            //args.Cancel(); 
        }
    }
}
