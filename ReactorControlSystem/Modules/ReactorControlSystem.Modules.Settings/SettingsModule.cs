using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ReactorControlSystem.Modules.Settings.ViewModels;
using ReactorControlSystem.Modules.Settings.Views;

namespace ReactorControlSystem.Modules.Settings
{
    public class SettingsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
        }
    }
}