namespace ConsoleMenu
{
    public class MenuItem : IMenuItem
    {
        // properties
        public bool CallMenu { get; set; } = true;

        private string _menuName = "";
        public string MenuName
        { 
            get => _menuName; 
            set
            {
                CallMenu = true;
                Run = false;
                _menuName = value;
            } 
        }

        public bool Run { get; set; } = false;
        
        private string _runName = "";
        public string RunName
        { 
            get => _runName; 
            set
            {
                CallMenu = false;
                Run = true;
                _runName = value;

                // ensure there is a returning point after running something
                _menuName = _menuName == "" ? "main" : _menuName;
            }
        }
        
        public string Text { get; set; } = "(no menu text defined)";

        public string MenuParent { get; private set; } = "";

        public string Name { get; set; }

        public MenuItem(string name, string text) 
        {
            Name = name;
            Text = text;
        }

        public void Reset()
        {
            Text = "(no menu text defined)";            
        }

        public void Runner()
        {
            if (Run != false)
            {
                // perform running something
            }
        }

        public void SetParent(IMenu parentMenu)
        {
            if (parentMenu == null) 
            {
                MenuParent = "main";
            }
            else
            {
                MenuParent = parentMenu.MenuParent + "|" + parentMenu.Name;
            }
        }

        public void ShowMenu(IMenuControl menuControl)
        {
            if (CallMenu != false)
            {
                menuControl.GetMenu(MenuName).GetFullMenu();
            }
        }
    }
}