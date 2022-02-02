using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dragablz;
using Dragablz.Dockablz;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using SAACHostel.Views;

namespace SAACHostel.ViewModels
{
    internal class JournalsViewModel : BindableBase
    {
        private IContainerProvider _containerProvider;
        private IRegionManager _regionManager;
        private IRegion _journalRegion;
        private IRegion _studentRegion;
        private IRegion _roomRegion;
        private IRegion _hostelRegion;
        private object _journalView;
        private object _studentView;
        private object _roomView;
        private object _hostelView;
        public DelegateCommand LoadData { get; private set; }
        public JournalsViewModel(IContainerProvider containerProvider, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            LoadData = new DelegateCommand(StartViewMethod);
        }
        private void StartViewMethod()
        {
            _journalRegion = _regionManager.Regions["JournalRegion"];
            _studentRegion = _regionManager.Regions["StudentRegion"];
            _roomRegion = _regionManager.Regions["RoomRegion"];
            _hostelRegion = _regionManager.Regions["HostelRegion"];

            _journalView = _containerProvider.Resolve<JournalView>();
            _studentView = _containerProvider.Resolve<StudentView>();
            _roomView = _containerProvider.Resolve<RoomView>();
            _hostelView = _containerProvider.Resolve<HostelView>();

            _journalRegion.Add(_journalView);
            _studentRegion.Add(_studentView);
            _roomRegion.Add(_roomView);
            _hostelRegion.Add(_hostelView);
        }
    }
}
