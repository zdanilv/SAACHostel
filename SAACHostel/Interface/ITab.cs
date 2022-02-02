using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.Interface
{
    internal interface ITab
    {
        string Name { get; set; }
        public DelegateCommand CloseCommand { get; }
        event EventHandler CloseRequested;
    }
    public abstract class Tab : ITab
    {
        public Tab()
        {
            CloseCommand = new DelegateCommand(EventCloseRequested);
        }
        public string Name { get; set; }
        public DelegateCommand CloseCommand { get; }
        public event EventHandler CloseRequested;
        private void EventCloseRequested()
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
