namespace TickerText.Menu;

public class TemplateMenu : IMenu
{
    public TemplateMenu()
    {

    }

    public void Show()
    {
        Console.WriteLine("=== Template Menu ===");
        Console.WriteLine("1. Show templates");
        Console.WriteLine("2. Create template");
        Console.WriteLine("3. Edit template");
        Console.WriteLine("4. Delete template");
        Console.WriteLine("5. Back to Main Menu");
    }

    public void HandleInput()
    {
        var inputManager = new InputManager<int>("Selection: ");
        
        switch (inputManager.ReceiveInput())
        {
            case 1:
                Program.TemplateManager.DisplayTemplates();
                
                break;
            case 2:
                Program.TemplateManager.CreateTemplate();
                
                break;
            case 3:
                Program.TemplateManager.EditTemplate();
                
                break;
            case 4:
                Program.TemplateManager.DeleteTemplate();
                
                break;
            case 5:
                IMenu menu = new MainMenu();
                
                MenuManager.Instance.SetCurrentMenu(menu);
                
                break;
            default:
                Console.WriteLine("Invalid Input!");
                
                HandleInput();
                
                break;
        }
        
        MenuManager.Instance.RunCurrentMenu(false);
    }
}