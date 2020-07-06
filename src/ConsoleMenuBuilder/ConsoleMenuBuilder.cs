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
        private Dictionary<string, OLD_Menu> _menuCollection = new Dictionary<string, OLD_Menu>();
        
        public bool AddMenu(string menuName, string headerText = "") {
            if (!_menuCollection.ContainsKey(menuName)) {
                headerText = headerText == "" ? menuName.ToUpper() : headerText.ToUpper();
                _menuCollection.Add(menuName, new OLD_Menu(headerText));
            } else {
                return false;
            }
            return true;
        }
        public string GetMenu(string menuName) {
            // create header
            string headerTitleStart = HeaderDividerSymbol + " " + _menuCollection[menuName].HeaderText;
            string headerTitleEnd = new string(' ', _headerCharacterWidth - headerTitleStart.Length - 1) + _headerDividerSymbol;
            string menuFullText = HeaderDivider + "\n"
                + HeaderDividerSpace + "\n"
                + headerTitleStart + headerTitleEnd + "\n"
                + HeaderDividerSpace + "\n"
                + HeaderDivider + "\n\n";

            // fill up with items (menu entries)
            foreach (string id in _menuCollection[menuName].Items.Keys) {
                menuFullText += _menuCollection[menuName].Items[id].ItemText + "\n";
            }

            // check if items exist and return depending on existence
            if (_menuCollection[menuName].Items.Count > 0) {
                // print menu and wait for user input
                Console.WriteLine(menuFullText);
                return Console.ReadLine();
            } else {
                Console.WriteLine(menuFullText);
                return "";
            }
        }

        // constructors
        public ConsoleMenuBuilder() {
            _menuEntryCount = 0;
        }

        // methods
        public bool AddMenuItem(string menuName, string itemID, string itemText = "") {
            // exit adding if menu not existing
            if (!_menuCollection.ContainsKey(menuName)) return false;
            
            // add item
            _menuCollection[menuName].AddItem(itemID, itemText);
            _menuEntryCount = _menuCollection.Count;

            return true;
        }

        /// <summary>
        ///     Will change Id and/or ItemText for given Item ID.
        ///     <param="newText">Set to null if no change to be made</param>
        ///     <param="newId">Set to null if no change to be made</param>
        /// </summary>
        public bool ChangeMenuItem(string menuName, string currentId, string newText = null, string newId = null) {
            if (!_menuCollection.ContainsKey(menuName)) return false;
            if (!_menuCollection[menuName].Items.ContainsKey(currentId)) return false;
            
            // change ID
            if (newId != null) {
                // overwrite current Id property
                _menuCollection[menuName].Items[currentId].Id = newId;
                
                // add key to a temp dictionary
                Dictionary<string, MenuItems> tempDict = new Dictionary<string, MenuItems>();
                tempDict.Add(newId, _menuCollection[menuName].Items[currentId]);
                
                // remove key from original dictionary and add the temp entry
                _menuCollection[menuName].Items.Remove(currentId);
                _menuCollection[menuName].Items.Add(newId, tempDict[newId]);

                // change currentId to newId for rest of method
                currentId = newId;
            }
            
            // change ItemText
            if (newText != null) _menuCollection[menuName].Items[currentId].ItemText = newText;

            return true;
        }

        public int Count() {
            return _menuEntryCount;
        }
    }
}