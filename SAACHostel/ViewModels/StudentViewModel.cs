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
using Prism.Events;
using Prism.Mvvm;

namespace SAACHostel.ViewModels
{
    internal class StudentViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        public DelegateCommand LoadData { get; private set; }
        public DelegateCommand StudentListAddCommand { get; set; }
        public DelegateCommand StudentAddCommand { get; set; }

        private bool _isStarted = false;

        private readonly ObservableCollection<HeaderedItemViewModel> _items;
        private readonly ObservableCollection<HeaderedItemViewModel> _toolItems = new ObservableCollection<HeaderedItemViewModel>();
        public StudentViewModel(IEventAggregator eventAggregator, params HeaderedItemViewModel[] items)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<Events.StudentOpenItemEvent>().Subscribe(StudentOpenMethod);

            LoadData = new DelegateCommand(StartViewMethod);
            StudentListAddCommand = new DelegateCommand(StudentListAddMethod);
            StudentAddCommand = new DelegateCommand(StudentAddMethod);

            _items = new ObservableCollection<HeaderedItemViewModel>(items);
            _items.RemoveAt(0);
        }
        private void StartViewMethod()
        {
            if (!_isStarted)
            {
                StudentListAddMethod();
                _isStarted = true;
            }
        }
        private void StudentListAddMethod()
        {
            _items.Add(new HeaderedItemViewModel { Header = "Список записей", Content = new Views.StudentItemListView() });
        }
        private void StudentAddMethod()
        {
            _items.Add(new HeaderedItemViewModel { Header = "Новая запись", Content = new Views.StudentItemInfoAdvancedView() { DataContext = Models.StudentItemOpenAddDataBase.GetViewModel(-1, _eventAggregator) } });
        }
        private void StudentOpenMethod(int id)
        {
            _items.Add(new HeaderedItemViewModel { Header = "Текущая запись", Content = new Views.StudentItemInfoAdvancedView() { DataContext = Models.StudentItemOpenAddDataBase.GetViewModel(id, _eventAggregator) } });
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
