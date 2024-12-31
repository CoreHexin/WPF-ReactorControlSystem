using Prism.Ioc;
using Prism.Modularity;
using ReactorControlSystem.Modules.Login.ViewModels;
using ReactorControlSystem.Modules.Login.Views;

namespace ReactorControlSystem.Modules.Login
{
    public class LoginModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();
        }
    }
}