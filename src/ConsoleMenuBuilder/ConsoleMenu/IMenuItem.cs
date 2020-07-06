namespace ConsoleMenu
{
    public interface IMenuItem : IMenuBase
    {
        // properties
        bool CallMenu { get; set; }
        string MenuName { get; set; }
        bool Run { get; set; }
        string RunName { get; set; }
        string Text { get; set; }

        // methods
        void ShowMenu(IMenuControl menuControl);
        void Runner();
    }
}