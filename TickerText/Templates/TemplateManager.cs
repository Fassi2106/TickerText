using System.Reflection;
using TickerText.Menu;
using TickerText.Text.Fonts;

namespace TickerText.Templates;

public class TemplateManager
{
    private readonly List<TextTemplate> _templates;

    private TextTemplate _selectedTemplate;
    
    public TemplateManager()
    {
        var defaultTemplate = CreateDefaultTemplate();

        _templates = new List<TextTemplate>()
        {
            defaultTemplate
        };

        _selectedTemplate = defaultTemplate;
    }

    private static TextTemplate CreateDefaultTemplate()
    {
        return new TextTemplate("Default", new FontBig(), ConsoleColor.White, 100, false);
    }

    public TextTemplate GetSelectedTemplate()
    {
        return _selectedTemplate;
    }
    
    public void DisplayTemplates()
    {
        Console.WriteLine("=== Templates ===");
        
        foreach (var template in _templates)
        {
            template.Display();
            
            Console.WriteLine();
        }
    }
    
    public void CreateTemplate()
    {
        Console.WriteLine("=== Create Template ===");

        var templateBuilder = new TextTemplateBuilder();

        var stringInputManager = new InputManager<string>("Name: ");
        
        templateBuilder.SetName(stringInputManager.ReceiveInput());

        var availableFonts = GetAvailableFonts();
        if (availableFonts.Count == 0)
        {
            Console.WriteLine("No fonts available. Template creation aborted.");
            return;
        }

        Console.WriteLine("Available Fonts:");
        for (var i = 0; i < availableFonts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableFonts[i].Name}");
        }

        var intInputManager = new InputManager<int>("Enter number of font: ");

        var fontSelection = intInputManager.ReceiveInput();

        while (fontSelection > availableFonts.Count)
        {
            Console.WriteLine("Invalid selection.");

            fontSelection = intInputManager.ReceiveInput();
        }

        templateBuilder.SetFont(availableFonts[fontSelection - 1]);

        stringInputManager = new InputManager<string>("Color: ");
        
        ConsoleColor color;

        while (!Enum.TryParse(stringInputManager.ReceiveInput(), out color))
        {
            Console.WriteLine("Invalid selection.");
        }
        
        templateBuilder.SetColor(color);

        intInputManager = new InputManager<int>("Speed in milliseconds: ");

        var speed = intInputManager.ReceiveInput();

        while (speed < 50)
        {
            Console.WriteLine("Minimum is 50");

            speed = intInputManager.ReceiveInput();
        }

        templateBuilder.SetSpeed(speed);
        
        var boolInputManager = new InputManager<bool>("Blinking: ");

        templateBuilder.SetBlinking(boolInputManager.ReceiveInput());

        var template = templateBuilder.Build();

        _templates.Add(template);

        Console.WriteLine("Template created successfully.");
    }

    public void EditTemplate()
    {
        Console.WriteLine("=== Edit Template ===");

        DisplayTemplates();

        TextTemplate? template = null;

        var stringInputManager = new InputManager<string>("Enter template name: ");
        
        while (template == null)
        {
            var templateSelection = stringInputManager.ReceiveInput();

            template = _templates.FirstOrDefault(t => t.Name.Equals(templateSelection));

            if (template == null)
            {
                Console.WriteLine("Template not found");
            }   
        }

        var templateBuilder = new TextTemplateBuilder(template);
        
        Console.WriteLine("Enter values. Leave empty to keep values.");

        stringInputManager = new InputManager<string>($"Name ({template.Name}): ", true);

        var value = stringInputManager.ReceiveInput();

        if (!string.IsNullOrEmpty(value))
        {
            templateBuilder.SetName(value);
        }
        
        var availableFonts = GetAvailableFonts();
        if (availableFonts.Count == 0)
        {
            Console.WriteLine("No fonts available. Template creation aborted.");
            return;
        }

        Console.WriteLine("Available Fonts:");
        for (var i = 0; i < availableFonts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableFonts[i].Name}");
        }

        var intInputManager = new InputManager<int>("Enter number of font: ");

        var fontSelection = intInputManager.ReceiveInput();

        while (fontSelection > availableFonts.Count || fontSelection<1)
        {
            Console.WriteLine("Invalid selection.");

            fontSelection = intInputManager.ReceiveInput();
        }

        templateBuilder.SetFont(availableFonts[fontSelection - 1]);
        

        stringInputManager = new InputManager<string>("Color: ", true);
        
        ConsoleColor color;

        while (!Enum.TryParse(stringInputManager.ReceiveInput(), out color))
        {
            Console.WriteLine("Invalid selection.");
        }
        
        templateBuilder.SetColor(color);
        
        intInputManager = new InputManager<int>("Speed in milliseconds: ");

        var speed = intInputManager.ReceiveInput();

        while (speed < 50)
        {
            Console.WriteLine("Minimum is 50");

            speed = intInputManager.ReceiveInput();
        }

        templateBuilder.SetSpeed(speed);
        
        var boolInputManager = new InputManager<bool>("Blinking: ", true);

        templateBuilder.SetBlinking(boolInputManager.ReceiveInput());
        
        var updatedTemplate = templateBuilder.Build();
        
        template.Name = updatedTemplate.Name;
        template.Font = updatedTemplate.Font;
        template.Color = updatedTemplate.Color;
        template.Blinking = updatedTemplate.Blinking;

        Console.WriteLine("Template updated successfully.");
    }

    public void DeleteTemplate()
    {
        Console.WriteLine("=== Delete Template ===");
        
        DisplayTemplates();
        
        TextTemplate? template = null;

        var stringInputManager = new InputManager<string>("Enter template name: ");
        
        while (template == null)
        {
            var templateSelection = stringInputManager.ReceiveInput();

            template = _templates.FirstOrDefault(t => t.Name.Equals(templateSelection));

            if (template == null)
            {
                Console.WriteLine("Template not found");
            }   
        }

        _templates.Remove(template);

        Console.WriteLine("Template deleted successfully.");
    }

    
    
    private List<IFont> GetAvailableFonts()
    {
        List<IFont> availableFonts = new List<IFont>();

        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();

        foreach (Type type in types)
        {
            if (typeof(IFont).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            {
                IFont font = (IFont)Activator.CreateInstance(type);
                availableFonts.Add(font);
            }
        }

        return availableFonts;
    }
}