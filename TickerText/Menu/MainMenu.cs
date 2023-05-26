namespace TickerText.Menu;

public class MainMenu : IMenu
{
    public MainMenu()
    {
        
    }
    
    public void Show()
    {
        Console.WriteLine("=== Main Menu ===");
        Console.WriteLine("1. Actions");
        Console.WriteLine("2. Templates");
        Console.WriteLine("3. Texts");
        Console.WriteLine("4. Exit");
    }

    public void HandleInput()
    {
        IMenu menu;
        
        var inputManager = new InputManager<int>("Selection: ");
        
        switch (inputManager.ReceiveInput())
        {
            case 1:
                menu = new ActionMenu();
                
                MenuManager.Instance.SetCurrentMenu(menu);
                
                break;
            case 2:
                menu = new TemplateMenu();
                
                MenuManager.Instance.SetCurrentMenu(menu);
                
                break;
            case 3:
                menu = new TextMenu();

                MenuManager.Instance.SetCurrentMenu(menu);

                break;
            case 4:
                Console.WriteLine("Exit selected.");
                
                Environment.Exit(0);
                
                break;
            default:
                Console.WriteLine("Invalid Input!");
                
                HandleInput();
                
                break;
        }
    }
}