using Prism.Mvvm;
using Prism.Services.Dialogs;
using ReactorControlSystem.Core.Models;
using System;
using System.Windows;

namespace ReactorControlSystem.Modules.Login.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public string Title => "账号登录";

        public string Version => Application.ResourceAssembly.GetName().Version.ToString();

        private LoginModel _loginModel = new LoginModel();
        public LoginModel LoginModel
        {
            get { return _loginModel; }
            set { SetProperty(ref _loginModel, value); }
        }

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
