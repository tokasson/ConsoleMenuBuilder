using System;

namespace ConsoleMenuBuilder
{
    class TestInterface : IMenu
    {
        private string _headerText = "(no header set)";
        public string HeaderText { 
            get => _headerText; 
            set {
                _headerText = value == "" ? "(no header set)" : value;
            } 
        }

        public void Run() {
            Console.WriteLine(HeaderText);
        }
    }
}