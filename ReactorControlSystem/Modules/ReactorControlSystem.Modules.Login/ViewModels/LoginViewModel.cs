using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using ReactorControlSystem.Core.Events;
using ReactorControlSystem.Modules.Login.Models;

namespace ReactorControlSystem.Modules.Login.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        private readonly IEventAggregator _eventAggregator;

        public string Title => "账号登录";

        public string Version => Application.ResourceAssembly.GetName().Version.ToString();

        private LoginModel _loginModel = new LoginModel();
        public LoginModel LoginModel
        {
            get { return _loginModel; }
            set { SetProperty(ref _loginModel, value); }
        }

        private DelegateCommand _loginCommand;

        public DelegateCommand LoginCommand =>
            _loginCommand
            ?? (
                _loginCommand = new DelegateCommand(Login, CanLogin)
                    .ObservesProperty(() => LoginModel.Username)
                    .ObservesProperty(() => LoginModel.Password)
            );

        public event Action<IDialogResult> RequestClose;

        public LoginViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        private void Login()
        {
            // todo: 后续创建用户表
            if (LoginModel.Username == "admin" && LoginModel.Password == "admin")
            {
                DialogParameters dialogParameters = new DialogParameters()
                {
                    { "User", LoginModel },
                };
                RequestClose.Invoke(new DialogResult(ButtonResult.OK, dialogParameters));
                return;
            }

            _eventAggregator.GetEvent<PopupMessageEvent>().Publish("用户名或密码错误");
        }

        private bool CanLogin()
        {
            return Validator.TryValidateObject(LoginModel, new ValidationContext(LoginModel), null);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters) { }
    }
}
