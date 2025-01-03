using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ReactorControlSystem.Modules.HardwareLoader.ViewModels;
using ReactorControlSystem.Modules.HardwareLoader.Views;

namespace ReactorControlSystem.Modules.HardwareLoader
{
    public class HardwareLoaderModule : IModule
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