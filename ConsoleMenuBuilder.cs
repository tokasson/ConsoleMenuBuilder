using System;
using System.Collections.Generic;

namespace ConsoleMenuBuilder
{
    class ConsoleMenuBuilder
    {
        private int _menuEntryCount;

        // HEADER DEFINITIONS
        private char _headerDividerSymbol = '#';
        public char HeaderDividerSymbol {
            get => _headerDividerSymbol;
            set => _headerDividerSymbol = value;
        }

        private int _headerCharacterWidth = 81;
        public int HeaderCharacterWidth {
            get => _headerCharacterWidth;
            set => _headerCharacterWidth = value;
        }

        private string _headerDivider = "";
        public string HeaderDivider {
            get {
                _headerDivider = _headerDivider == "" ? new string(_headerDividerSymbol, _headerCharacterWidth) : _headerDivider;
                return _headerDivider;
            }
        }

        private string _headerDividerSpace = "";
        public string HeaderDividerSpace {
            get {
                _headerDividerSpace = _headerDividerSpace == "" ? _headerDividerSymbol + new string(' ', _headerCharacterWidth - 2) + _headerDividerSymbol : _headerDividerSpace;
                return _headerDividerSpace;
            }
        }

        // MENU DICTIONARY
        private Dictionary<string, Menu> _menuCollection = new Dictionary<string, Menu>();
        public bool AddMenu(string menuName, string headerText = "") {
            if (!_menuCollection.ContainsKey(menuName)) {
                headerText = headerText == "" ? menuName.ToUpper() : headerText.ToUpper();
                _menuCollection.Add(menuName, new Menu(headerText));
            } else {
                return false;
            }
            return true;
        }
        public string GetMenu(string menuName) {
            string headerTitleStart = HeaderDividerSymbol + " " + _menuCollection[menuName].HeaderText;
            string headerTitleEnd = new string(' ', _headerCharacterWidth - headerTitleStart.Length - 1) + _headerDividerSymbol;
            string menuFullText = HeaderDivider + "\n"
                + HeaderDividerSpace + "\n"
                + headerTitleStart + headerTitleEnd + "\n"
                + HeaderDividerSpace + "\n"
                + HeaderDivider;
            return menuFullText;
        }

        // constructors
        public ConsoleMenuBuilder() {
            _menuEntryCount = 0;
        }

        // methods
        public bool AddMenuItem(string menuName, int itemID) {
            // exit adding if menu not existing
            if (!_menuCollection.ContainsKey(menuName)) return false;
            
            // add item


            return true;
        }
        public int Count() {
            return _menuEntryCount;
        }
    }

    class Menu
    {
        private string _headerText = "NO TEXT SET YET";
        
        private Dictionary<int, MenuItems> _items = new Dictionary<int, MenuItems>();
        public string GetItem(int id) {
            return _items[id];
        }

        public string HeaderText { 
            get => _headerText; 
            set => _headerText = value; 
        }       
        public Menu(string headerText) {
            _headerText = headerText;
        }
    }

    class MenuItems
    {
        
    }
}