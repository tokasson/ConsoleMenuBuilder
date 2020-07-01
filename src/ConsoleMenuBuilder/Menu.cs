using System;
using System.Collections.Generic;

namespace ConsoleMenuBuilder
{
    class Menu : IMenu
    {
        //private string _headerText = "(NO HEADER TEXT DEFINED)";
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

        /*
        public string HeaderText { 
            get => _headerText; 
            set => _headerText = value; 
        } 
        */

        public Menu(string headerText) {
            HeaderText = headerText;
        }
    }
}