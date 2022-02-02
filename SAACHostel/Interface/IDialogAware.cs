using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.Interface
{
    public interface IDialogAware
    {
        public string IconSource { get; set; }
        string Title { get; set; }
        bool CanCloseDialog();
        void OnDialogClosed();
        void OnDialogOpened(IDialogParameters parameters);
        event Action<IDialogResult> RequestClose;
    }
}
