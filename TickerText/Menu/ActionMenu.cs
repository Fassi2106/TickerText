using TickerText.Text;

namespace TickerText.Menu;

public class ActionMenu : IMenu
{
    public ActionMenu()
    {
        
    }

    public void Show()
    {
        Console.WriteLine("=== Action Menu ===");
        Console.WriteLine("1. Run Text");
        Console.WriteLine("2. Back to Main Menu");
    }

    public void HandleInput()
    {
        var inputManager = new InputManager<int>("Selection: ");
        
        switch (inputManager.ReceiveInput())
        {
            case 1:
                RunText();
                
                break;
            case 2:
                var menu = new MainMenu();
                
                Program.MenuManager.SetCurrentMenu(menu);
                
                break;
            default:
                Console.WriteLine("Invalid input!");
                
                HandleInput();
                
                break;
        }
    }

    private static void RunText()
    {
        var inputManager = new InputManager<string>("Enter text to display: ");

        var text = inputManager.ReceiveInput();

        var asciiText = AsciiArtGenerator.GenerateAsciiArt(text, Program.TemplateManager.GetSelectedTemplate());

        var textRunner = new TextRunner(asciiText, Program.TemplateManager.GetSelectedTemplate().SpeedInMillis);
        
        textRunner.Start();
    }
}