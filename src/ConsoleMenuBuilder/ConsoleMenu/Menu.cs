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

        public List<IMenuItem> MenuItems { get; set; } = new List<IMenuItem>();

        public string MenuParent { get; private set; } = "";
        
        public string Name { get; set; } = "main";

        public bool ShowMenuPath { get; set; } = false;

        public bool UseNamesAsHeader { get; set; } = false;

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

        public bool AddMenuItem(string itemText)
        {
            int countItems = MenuItems.Count;
            MenuItems.Add(new MenuItem(Name + "_" + (countItems + 1).ToString(), itemText));
            return countItems < MenuItems.Count;
        }
        
        public string BuildHeader()
        {
            string[] parentNames = MenuParent.Split('|');
            string buildMenuPath = "";
            if (parentNames.Length > 1)
            {
                foreach (string parentName in parentNames)
                {
                    if (parentName == "") continue;
                    buildMenuPath += parentName + " > ";
                }
            }
            buildMenuPath += Name;

            string fullFrameLine = new string(HeaderFrameChar, HeaderFrameCharCount) + "\n";
            string frameLineSpace = HeaderFrameChar + new string(' ', HeaderFrameCharCount - 2) + HeaderFrameChar + "\n";
            string framedHeaderText = HeaderFrameChar + " " + HeaderTitle + new string(' ', HeaderFrameCharCount - HeaderTitle.Length - 3) + HeaderFrameChar + "\n";
            string fullHeader;

            if (UseNamesAsHeader)
            {
                string framedNames = HeaderFrameChar + " " + buildMenuPath.ToUpper() + new string(' ', HeaderFrameCharCount - buildMenuPath.Length - 3) + HeaderFrameChar + "\n";
                fullHeader = fullFrameLine + frameLineSpace + framedNames + frameLineSpace + fullFrameLine;
            }
            else if (ShowMenuPath)
            {
                string framedHeaderMenuPath = HeaderFrameChar + " (" + buildMenuPath + ")" + new string(' ', HeaderFrameCharCount - buildMenuPath.Length - 5) + HeaderFrameChar + "\n";
                fullHeader = fullFrameLine + frameLineSpace + framedHeaderText + framedHeaderMenuPath + frameLineSpace + fullFrameLine;
            }
            else
            {
                fullHeader = fullFrameLine + frameLineSpace + framedHeaderText + frameLineSpace + fullFrameLine;
            }

            return fullHeader;
            
        }

        public string BuildItems()
        {
            string buildItems = "";
            int index = 0;
            foreach (IMenuItem menuItem in MenuItems)
            {
                buildItems += (++index).ToString() + ". " + menuItem.Text + "\n";
            }
            return buildItems;
        }

        public string GetFullMenu()
        {
            Console.Clear();
            Console.WriteLine(GetHeader() + "\n" + GetItems() + "\n");
            Console.Write("Enter choice: ");
            
            // get choice from user and check what was specified to be done
            string choice = Console.ReadLine().ToString();
            IMenuItem menuItem = GetMenuItem(Name + "_" + choice);
            if (menuItem.CallMenu)
            {
                return menuItem.MenuName;
            }
            else
            {
                Console.WriteLine("Run whatever was specified: {0}", menuItem.RunName);
                Console.ReadKey();
                return menuItem.MenuName;
            }
        }

        public string GetHeader()
        {
            if (HasHeader == true) return BuildHeader();
            return "";
        }

        public string GetItems()
        {
            return BuildItems();
        }

        public IMenuItem GetMenuItem(string itemName)
        {
            foreach (IMenuItem menuItem in MenuItems)
            {
                if (menuItem.Name == itemName)
                {
                    return menuItem;
                }
            }
            return null;
        }

        public void Reset()
        {
            HeaderTitle = "(no header set)";
            HasHeader = false;
            ShowMenuPath = true;
            UseNamesAsHeader = false;
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
    }
}