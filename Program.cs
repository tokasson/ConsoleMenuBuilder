using System;

namespace ConsoleMenuBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenuBuilder cmb = new ConsoleMenuBuilder();
            if (cmb.AddMenu("main", "my own header for main")) Console.WriteLine("Successfully added main!");

            Console.WriteLine(cmb.HeaderDivider);
            Console.WriteLine(cmb.GetMenu("main"));
        }
    }
}
