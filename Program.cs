using ConsoleMenu;
using System;
using System.Collections.Generic;

namespace ConsoleMenuBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenuControl menuList = new MenuControl();
            IMenu m;

            menuList.AddMenu(null, "main");
            menuList.GetMenu("main").HeaderTitle = "This is my header";
            menuList.GetMenu("main").AddMenuItem("Exit this");
            menuList.GetMenu("main").GetMenuItem("main_1").MenuName = "FULL_EXIT";

            menuList.AddMenu(menuList.GetMenu("main"), "sub1");
            menuList.GetMenu("sub1").HeaderTitle = "This is SUB1";

            menuList.AddMenu(menuList.GetMenu("sub1"), "sub1sub1");
            m = menuList.GetMenu("sub1sub1");
            m.HeaderTitle = "This is SUB1 below SUB1";
            m.UseNamesAsHeader = true;
            m.AddMenuItem("I am Text 1");
            m.AddMenuItem("I am Text 2");
            m.AddMenuItem("I am Text 3");

            m.GetMenuItem("sub1sub1_1").MenuName = "main";
            
            bool exitConsole = false;
            string currentMenu = "sub1sub1";
            string chosenMenu = "";
            while (exitConsole == false)
            {
                // run menu
                chosenMenu = menuList.GetMenu(currentMenu).GetFullMenu();
                
                // check if exit was set
                exitConsole = chosenMenu == "FULL_EXIT";
                
                // change menu choice
                currentMenu = chosenMenu;
            }

            /*
            // create new instance of menu builder
            ConsoleMenuBuilder cmb = new ConsoleMenuBuilder();

            // create new menu and add entries
            cmb.AddMenu("main", "main menu");            
            cmb.AddMenuItem("main", "1", "Settings");
            cmb.AddMenuItem("main", "WHOA", "Show data");
            cmb.AddMenuItem("main", "3", "Settings");
            cmb.AddMenuItem("main", "4", "Exit tool");
            cmb.AddMenu("settings", "main menu > settings");
            cmb.AddMenuItem("settings", "1", "Change behaviour 1");
            cmb.AddMenuItem("settings", "2", "Change behaviour 2");
            cmb.AddMenuItem("settings", "3", "Change behaviour 3");
            cmb.AddMenuItem("settings", "4", "Change behaviour 4");
            cmb.AddMenuItem("settings", "5", "Change behaviour 5");
            cmb.AddMenuItem("settings", "6", "Change behaviour 6");
            cmb.AddMenuItem("settings", "7", "Back to main menu");

            // change existing entry
            cmb.ChangeMenuItem("main", "WHOA", newId:"2");
            
            // user choice
            string currentMenu = "main";
            string userChoice = "";
            
            // display menu in loop until 4 chosen in main
            while ((currentMenu != "main") && (userChoice != "4")) {
                userChoice = cmb.GetMenu(currentMenu);
                switch (currentMenu) {
                    case "main":
                        
                        break;
                    case "settings":
                        break;
                    default:
                        break;
                }
            }
            */
        }
    }
}
