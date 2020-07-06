using System.Collections.Generic;

namespace ConsoleMenu
{
    public interface IMenu : IMenuBase
    {
        // props
        bool HasHeader { get; }
        char HeaderFrameChar { get; set; }
        int HeaderFrameCharCount { get; set; }
        string HeaderTitle { get; set; }
        List<IMenuItem> MenuItems { get; set; }
        bool ShowMenuPath { get; set; }
        bool UseNamesAsHeader { get; set; }

        // methods
        bool AddMenuItem(string itemText);
        string BuildHeader();
        string GetFullMenu();
        string GetHeader();
        string GetItems();
        IMenuItem GetMenuItem(string itemName);
    }
}