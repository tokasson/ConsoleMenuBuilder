namespace ConsoleMenu
{
    public interface IMenu
    {
        // props
        bool HasHeader { get; }
        char HeaderFrameChar { get; set; }
        int HeaderFrameCharCount { get; set; }
        string HeaderTitle { get; set; }
        string MenuParent { get; }
        string Name { get; set; }
        bool UseNamesAsHeader { get; set; }

        // methods
        string BuildHeader();
        string GetHeader();
        void Reset();
        void SetParent(IMenu parentMenu);

    }
}