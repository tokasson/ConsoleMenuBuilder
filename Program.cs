using System;

namespace ConsoleMenuBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenuBuilder cmb = new ConsoleMenuBuilder();
            cmb.AddMenu("main", "main menu");
            cmb.AddMenu("addnew", "main menu > add new entry to something");
            cmb.AddMenuItem("main", "1", "My first menu entry");
            cmb.AddMenuItem("main", "WHOA", "My second menu entry");
            cmb.ChangeMenuItem("main", "WHOA", newId:"2");

            Console.WriteLine(cmb.GetMenu("main"));
            Console.WriteLine(cmb.GetMenu("addnew"));
        }
    }
}
