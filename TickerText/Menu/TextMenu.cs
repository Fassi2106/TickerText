namespace TickerText.Menu;

public class TextMenu  : IMenu
{
    public TextMenu()
    {
        
    }

    public void Show()
    {
        Console.WriteLine("=== Text Menu ===");
        Console.WriteLine("1. Show texts");
        Console.WriteLine("2. Create text");
        Console.WriteLine("3. Edit text");
        Console.WriteLine("4. Delete text");
        Console.WriteLine("5. Back to Main Menu");
    }
    
    public void HandleInput()
    {
        var inputManager = new InputManager<int>("Selection: ");
        
        switch (inputManager.ReceiveInput())
        {
            case 1:
                Program.TextManager.DisplayTexts();
                
                break;
            case 2:
                Program.TextManager.CreateText();
                
                break;
            case 3:
                Program.TextManager.EditText();
                
                break;
            case 4:
                Program.TextManager.DeleteText();
                
                break;
            case 5:
                IMenu menu = new MainMenu();
                
                Program.MenuManager.SetCurrentMenu(menu);
                
                break;
            default:
                Console.WriteLine("Invalid Input!");
                
                HandleInput();
                
                break;
        }
        
        Program.MenuManager.RunCurrentMenu(false);
    }
}