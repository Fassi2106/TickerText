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
        Console.WriteLine("1. Run saved text");
        Console.WriteLine("2. Run individual text");
        Console.WriteLine("3. Select template");
        Console.WriteLine("4. Back to Main Menu");
    }

    public void HandleInput()
    {
        var inputManager = new InputManager<int>("Selection: ");
        
        switch (inputManager.ReceiveInput())
        {
            case 1:
                RunSavedText();
                
                break;
            case 2:
                RunIndividualText();
                
                break;
            case 3:
                SelectTemplate();
                
                Program.MenuManager.SetCurrentMenu(this);
                
                break;
            case 4:
                var menu = new MainMenu();
                
                Program.MenuManager.SetCurrentMenu(menu);
                
                break;
            default:
                Console.WriteLine("Invalid input!");
                
                HandleInput();
                
                break;
        }
    }

    private static void RunSavedText()
    {
        var availableTexts = Program.TextManager.GetTexts();
        if (availableTexts.Count == 0)
        {
            Console.WriteLine("No texts available.");
            return;
        }
        
        Console.WriteLine("Available Texts:");

        for (var i = 0; i < availableTexts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableTexts[i]}");
        }

        var intInputManager = new InputManager<int>("Enter number of text: ");

        var textSelection = intInputManager.ReceiveInput();

        while (textSelection > availableTexts.Count || textSelection < 1)
        {
            Console.WriteLine("Invalid selection.");

            textSelection = intInputManager.ReceiveInput();
        }
        
        var text = availableTexts[textSelection-1];
        
        var asciiText = AsciiArtGenerator.GenerateAsciiArt(text, Program.TemplateManager.GetSelectedTemplate());

        var template = Program.TemplateManager.GetSelectedTemplate();
        
        var textRunner = new TextRunner(asciiText, template.SpeedInMillis, template.Color, template.Blinking);
        
        textRunner.Start();
    }
    
    private static void RunIndividualText()
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