using TickerText.Templates;
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
        Console.WriteLine("1. Run text");
        Console.WriteLine("2. Select template");
        Console.WriteLine("3. Back to Main Menu");
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
                SelectTemplate();
                
                Program.MenuManager.SetCurrentMenu(this);
                
                break;
            case 3:
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

        var template = Program.TemplateManager.GetSelectedTemplate();
        
        var textRunner = new TextRunner(asciiText, template.SpeedInMillis, template.Color, template.Blinking);
        
        textRunner.Start();
    }

    private static void SelectTemplate()
    {
        Program.TemplateManager.DisplayTemplates();

        var stringInputManager = new InputManager<string>("Enter template name: ");

        TextTemplate? template = null;

        while (template == null)
        {
            var templateSelection = stringInputManager.ReceiveInput();

            template = Program.TemplateManager.GetTemplates().FirstOrDefault(t => t.Name.Equals(templateSelection));

            if (template == null)
            {
                Console.WriteLine("Template not found");
            }
        }
        
        Program.TemplateManager.SetSelectedTemplate(template);
    }
}