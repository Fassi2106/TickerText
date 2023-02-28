namespace TickerText;

public class MenuManager
{
    public MenuManager()
    {
        IMenu menu = new MainMenu();
        while (true)
        {
            Console.Clear();
            var menuType = menu.StartMenu();

            menu = menuType switch
            {
                MenuType.MainMenu => new MainMenu(),
                MenuType.DisplaySettings => new DisplaySettings(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}