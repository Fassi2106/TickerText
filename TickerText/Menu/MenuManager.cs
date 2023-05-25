namespace TickerText.Menu;

public class MenuManager
{
    private IMenu _currentMenu = new MainMenu();

    public void Start()
    {
        RunCurrentMenu();
    }

    public void SetCurrentMenu(IMenu menu)
    {
        _currentMenu = menu;
        
        RunCurrentMenu();
    }

    public void RunCurrentMenu(bool clear = true)
    {
        if (clear)
        {
            Console.Clear();
        }

        _currentMenu.Show();
        _currentMenu.HandleInput();
    }
}