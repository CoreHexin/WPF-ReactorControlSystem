using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ReactorControlSystem.Modules.Reactor.ViewModels;
using ReactorControlSystem.Modules.Reactor.Views;

namespace ReactorControlSystem.Modules.Reactor
{
    public class ReactorModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ReactorView, ReactorViewModel>();
        }
    }
}