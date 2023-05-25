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
        Console.WriteLine("3. Exit");
    }

    public void HandleInput()
    {
        IMenu menu;
        
        var inputManager = new InputManager<int>("Selection: ");
        
        switch (inputManager.ReceiveInput())
        {
            case 1:
                menu = new ActionMenu();
                
                Program.MenuManager.SetCurrentMenu(menu);
                
                break;
            case 2:
                menu = new TemplateMenu();
                
                Program.MenuManager.SetCurrentMenu(menu);
                
                break;
            case 3:
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