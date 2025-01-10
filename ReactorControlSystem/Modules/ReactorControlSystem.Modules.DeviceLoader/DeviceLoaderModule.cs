using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ReactorControlSystem.Modules.DeviceLoader.ViewModels;
using ReactorControlSystem.Modules.DeviceLoader.Views;

namespace ReactorControlSystem.Modules.DeviceLoader
{
    public class DeviceLoaderModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<Loader, LoaderViewModel>();
        }
    }
}