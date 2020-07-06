namespace ConsoleMenu
{
    public interface IMenuBase
    {
        // properties
        string MenuParent { get; }
        string Name { get; set; }

        // methods
        void Reset();
        void SetParent(IMenu parentMenu);
    }
}