using System;
using System.Collections.Generic;

namespace ConsoleMenu
{
    public class MenuControl : IMenuControl
    {
        public List<IMenu> ListOfMenus { get; set; } = new List<IMenu>();

        public MenuControl()
        {
            // keep standard values
        }
        public bool AddMenu(IMenu parentMenu, string menuName)
        {
            // set according to parent menu
            if (parentMenu == null)
            {
                // error - can't create main twice
                if (ListOfMenus.Count > 0)
                {
                    Console.WriteLine("Main menu creation failed - \"main\" does already exist");
                    return false;
                }

                // create main
                ListOfMenus.Add(new Menu());
                return true;
            }
            else
            {
                IMenu menu = GetMenu(menuName);
                
                // if menu was found stop creation
                if (menu != null)
                {
                    Console.WriteLine($"Menu creation failed - \"{ menuName }\" does already exist");
                    return false;
                }
                
                // create menu if not found
                ListOfMenus.Add(new Menu(parentMenu, menuName));
                return true;
            }
        }

        public IMenu GetMenu(string menuName)
        {
            foreach (IMenu menu in ListOfMenus)
            {
                if (menu.Name == menuName)
                {
                    return menu;
                }
            }
            return null;
        }
    }
}