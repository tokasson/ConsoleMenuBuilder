using System;

namespace ConsoleMenuBuilder
{
    class MenuItems
    {
        private string _id;
        public string Id {
            get => _id;
            set => _id = value;
        }
        public MenuItems(string id) {
            // id can be set by user and will reflect the "choice letter/number" from the menu
            Id = id;
        }

        private string _itemText = "(item text is not defined)";
        public string ItemText {
            get => $"{_id}. {_itemText}";
            set => _itemText = value;
        }
    }
}