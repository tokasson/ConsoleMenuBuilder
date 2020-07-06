using System.Collections.Generic;

namespace ConsoleMenu
{
    public interface IMenuControl
    {
        // props
        List<IMenu> ListOfMenus { get; set; }

        // methods
        bool AddMenu(IMenu parentMenu, string menuName);
        IMenu GetMenu(string menuName);
    }
}