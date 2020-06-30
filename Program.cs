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

            Console.WriteLine(cmb.GetMenu("main"));
            Console.WriteLine(cmb.GetMenu("addnew"));
        }
    }
}
