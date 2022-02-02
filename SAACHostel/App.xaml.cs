using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using SAACHostel.ViewModels;
using SAACHostel.Views;
using Prism.Services.Dialogs;
using Prism.Modularity;

namespace SAACHostel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<DialogProfileView, DialogProfileViewModel>();
            containerRegistry.RegisterDialog<DialogAboutView, DialogAboutViewModel>();
            containerRegistry.RegisterDialog<DialogUniversityView, DialogUniversityViewModel>();
            containerRegistry.RegisterDialog<DialogSettingsView, DialogSettingsViewModel>();
        }
    }
}
