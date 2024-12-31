using System;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Services.Dialogs;
using ReactorControlSystem.Modules.Login;
using ReactorControlSystem.Modules.Login.Views;
using ReactorControlSystem.Views;

namespace ReactorControlSystem
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

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<LoginModule>();
        }

        protected override void OnInitialized()
        {
            var dialogService = Container.Resolve<IDialogService>();
            dialogService.ShowDialog(nameof(LoginView), LoginCallback);
        }

        private void LoginCallback(IDialogResult diaglogResult)
        {
            if (diaglogResult.Result != ButtonResult.OK)
            {
                Environment.Exit(0);
                return;
            }

            base.OnInitialized();
        }
    }
}
