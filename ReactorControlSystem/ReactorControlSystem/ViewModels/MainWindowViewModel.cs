using System.Collections.Generic;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ReactorControlSystem.Core.Constants;
using ReactorControlSystem.Devices;
using ReactorControlSystem.Models;

namespace ReactorControlSystem.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly DevicesManager _devicesManager;

        public List<Menu> Menus { get; set; }

        private Menu _selectedMenu;
        public Menu SelectedMenu
        {
            get { return _selectedMenu; }
            set { SetProperty(ref _selectedMenu, value); }
        }

        private DelegateCommand<string> _navigateCommand;

        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ??= new DelegateCommand<string>(Navigate);

        private DelegateCommand _unloadDevicesCommand;
        public DelegateCommand UnloadDevicesCommand =>
            _unloadDevicesCommand ??= new DelegateCommand(UnLoadDevices);

        private DelegateCommand _onLoadedCommand;
        public DelegateCommand OnLoadedCommand =>
            _onLoadedCommand ??= new DelegateCommand(OnLoaded);

        public MainWindowViewModel(IRegionManager regionManager, DevicesManager devicesManager)
        {
            _regionManager = regionManager;
            _devicesManager = devicesManager;
            LoadMenus();
        }

        private void Navigate(string target)
        {
            if (!string.IsNullOrEmpty(target))
            {
                _regionManager.Regions[RegionNames.ContentRegion].RequestNavigate(target);
            }
        }

        private void LoadMenus()
        {
            Menus = new List<Menu>()
            {
                new Menu()
                {
                    Title = "首页",
                    Icon = "Home",
                    Target = ViewNames.HomeView,
                },
                new Menu()
                {
                    Title = "1#反应釜",
                    Icon = "Flask",
                    Target = ViewNames.ReactorView,
                },
                new Menu() { Title = "2#反应釜", Icon = "Flask" },
                new Menu() { Title = "加料泵操作", Icon = "FlaskEmptyPlusOutline" },
                new Menu()
                {
                    Title = "历史数据",
                    Icon = "Table",
                    Target = ViewNames.HistoryView,
                },
                new Menu()
                {
                    Title = "系统设置",
                    Icon = "CogOutline",
                    Target = ViewNames.SettingsView,
                },
            };
        }

        private void OnLoaded()
        {
            SelectedMenu = Menus[0];
            Navigate(ViewNames.HomeView);
        }

        /// <summary>
        /// 当关闭窗口时, 卸载所有设备
        /// </summary>
        private void UnLoadDevices()
        {
            _devicesManager.DisconnectAll();
        }
    }
}
