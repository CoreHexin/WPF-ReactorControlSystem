using Prism.Mvvm;
using ReactorControlSystem.Core.Models;
using System.Collections.Generic;


namespace ReactorControlSystem.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public List<Menu> Menus { get; set; }

        private Menu _selectedMenu;
        public Menu SelectedMenu
        {
            get { return _selectedMenu; }
            set { SetProperty(ref _selectedMenu, value); }
        }

        public MainWindowViewModel()
        {
            LoadMenus();
        }

        private void LoadMenus()
        {
            Menus = new List<Menu>()
            {
                new Menu() { Title="首页", Icon="Home" },
                new Menu() { Title="1#反应釜", Icon="Flask" },
                new Menu() { Title="2#反应釜", Icon="Flask" },
                new Menu() { Title="加料泵操作", Icon="FlaskEmptyPlusOutline" },
                new Menu() { Title="历史数据", Icon="Table" },
                new Menu() { Title="系统设置", Icon="CogOutline" }
            };
        }
    }
}
