using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReactorControlSystem.Modules.Login.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public string Title => "账号登录";

        public event Action<IDialogResult> RequestClose;

        public LoginViewModel()
        {

        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
