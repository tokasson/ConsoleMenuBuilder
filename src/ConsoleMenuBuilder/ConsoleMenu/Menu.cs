using System;
using System.Collections.Generic;

namespace ConsoleMenu
{
    public class Menu : IMenu
    {
        public bool HasHeader { get; private set; } = false;
        
        public char HeaderFrameChar { get; set; } = '#';
        
        public int  HeaderFrameCharCount { get; set; } = 90;
        
        private string _headerTitle = "(no header set)";
        public string HeaderTitle
        { 
            get { return _headerTitle; }

            set 
            {
                // ensure that HasHeader is set to true automatically when setting the title
                _headerTitle = value;
                HasHeader = true;
            } 
        }
        
        public string MenuParent { get; private set; } = "";
        
        public string Name { get; set; } = "main";

        public string UseNamesAsHeader { get; set; } = false;

        public Menu() 
        {
            // keep standard values
        }
        
        public Menu(IMenu parentMenu, string menuName)
        {
            // set according to parent menu
            Name = menuName;
            SetParent(parentMenu);
        }

        public string BuildHeader()
        {
            string[] parentNames = MenuParent.Split('|');
            string buildMenuPath = "(";
            if (parentNames.Length > 1)
            {
                foreach (string parentName in parentNames)
                {
                    if (parentName == "") continue;
                    buildMenuPath += parentName + " > ";
                }
            }
            buildMenuPath += Name + ")";

            string fullFrameLine = new string(HeaderFrameChar, HeaderFrameCharCount) + "\n";
            string frameLineSpace = HeaderFrameChar + new string(' ', HeaderFrameCharCount - 2) + HeaderFrameChar + "\n";
            string framedHeaderText = HeaderFrameChar + " " + HeaderTitle + new string(' ', HeaderFrameCharCount - HeaderTitle.Length - 3) + HeaderFrameChar + "\n";
            string framedHeaderMenuPath = HeaderFrameChar + " " + buildMenuPath + new string(' ', HeaderFrameCharCount - buildMenuPath.Length - 3) + HeaderFrameChar + "\n";
            return fullFrameLine + frameLineSpace + framedHeaderText + framedHeaderMenuPath + frameLineSpace + fullFrameLine;
        }

        public string GetHeader()
        {
            if (HasHeader == true) return BuildHeader();
            return "";
        }

        public void Reset()
        {
            HeaderTitle = "(no header set)";
            HasHeader = false;
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

        /*
        public string HeaderText {
            get => HeaderText;
            set {
                HeaderText = value == "" ? "(no header set)" : value;
            }
        }

        private Dictionary<string, MenuItems> _items = new Dictionary<string, MenuItems>();
        public Dictionary<string, MenuItems> Items {
            get => _items;
        }

        public bool AddItem(string id, string itemText = "") {
            if (id == "") return false;
            _items.Add(id, new MenuItems(id));            
            if (itemText != "") {
               _items[id].ItemText = itemText;     
            }            
            return true;
        }

        public string GetItem(string id) {
            return _items[id].ItemText;
        }

        public string HeaderText { 
            get => _headerText; 
            set => _headerText = value; 
        } 
        

        public Menu(string headerText) {
            HeaderText = headerText;
        }
        */
    }
}