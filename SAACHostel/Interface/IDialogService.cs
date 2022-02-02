using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.Interface
{
    public interface IDialogService
    {
        void Show(string name, IDialogParameters parameters, Action<IDialogResult> callback);
        void ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback);
    }
}
