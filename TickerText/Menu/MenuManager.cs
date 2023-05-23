namespace TickerText.Menu;

public class MenuManager
{
    private IMenu currentMenu;

    public void Start()
    {
        MainMenu mainMenu = new MainMenu();
        SetCurrentMenu(mainMenu);
        RunCurrentMenu();
    }

    private void SetCurrentMenu(IMenu menu)
    {
        currentMenu = menu;
    }

    private void RunCurrentMenu()
    {
        currentMenu.Show();
        currentMenu.HandleInput();
        RunCurrentMenu(); // Rekursiver Aufruf, um das Menü am Ende der Verarbeitung erneut anzuzeigen
    }
}