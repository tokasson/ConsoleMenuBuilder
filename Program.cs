using System;

namespace ConsoleMenuBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
