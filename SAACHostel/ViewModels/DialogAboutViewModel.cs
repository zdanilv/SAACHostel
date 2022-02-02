using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.ViewModels
{
    internal class DialogAboutViewModel : DialogViewModelBase
    {
        public DelegateCommand CloseDialogCommand { get; set; }

        public DialogAboutViewModel()
        {
            Title = "О Программе";
            CloseDialogCommand = new DelegateCommand(CloseDialogMethod);
        }
        private void CloseDialogMethod()
        {
            RaiseRequestClose(new DialogResult(ButtonResult.Cancel));
        }
        public override void OnDialogOpened(IDialogParameters parameters)
        {
            //Message = parameters.GetValue<string>("message");
        }
    }
}
