namespace TickerText.Menu;

public class MenuManager
{
    private IMenu _currentMenu = new MainMenu();

    private static MenuManager? _instance;
    
    public static MenuManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MenuManager();
            }

            return _instance;
        }
    }
    
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