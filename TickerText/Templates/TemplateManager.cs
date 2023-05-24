using System.Reflection;
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

    public static TextTemplate CreateDefaultTemplate()
    {
        return new TextTemplate("Default", new FontBig(), ConsoleColor.White, false);
    }

    public TextTemplate GetSelectedTemplate()
    {
        return _selectedTemplate;
    }
    
    public void CreateTemplate()
    {
        Console.WriteLine("=== Create Template ===");

        TextTemplateBuilder templateBuilder = new TextTemplateBuilder();

        Console.Write("Name: ");
        templateBuilder.SetName(Console.ReadLine());

        List<IFont> availableFonts = GetAvailableFonts();
        if (availableFonts.Count == 0)
        {
            Console.WriteLine("No fonts available. Template creation aborted.");
            return;
        }

        Console.WriteLine("Available Fonts:");
        for (int i = 0; i < availableFonts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableFonts[i].Name}");
        }

        int fontChoice = GetInputInRange("Enter the number of the desired font: ", 1, availableFonts.Count);
        templateBuilder.SetFont(availableFonts[fontChoice - 1]);

        Console.Write("Color: ");
        ConsoleColor color;
        if (!Enum.TryParse(Console.ReadLine(), out color))
        {
            Console.WriteLine("Invalid input for Color. Template creation aborted.");
            return;
        }
        templateBuilder.SetColor(color);

        Console.Write("Blinking (Y/N): ");
        bool blinking = (Console.ReadLine().ToUpper() == "Y");
        templateBuilder.SetBlinking(blinking);

        TextTemplate template = templateBuilder.Build();

        _templates.Add(template);

        Console.WriteLine("Template created successfully.");
    }

    public void EditTemplate()
    {
        Console.WriteLine("=== Edit Template ===");
        Console.Write("Enter template name: ");
        string templateName = Console.ReadLine();

        TextTemplate template = _templates.Find(t => t.Name == templateName);
        if (template == null)
        {
            Console.WriteLine("Template not found.");
            return;
        }

        Console.WriteLine("Enter new values (press Enter to keep current value):");

        TextTemplateBuilder templateBuilder = new TextTemplateBuilder();

        Console.Write($"Name ({template.Name}): ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
        {
            templateBuilder.SetName(newName);
        }

        List<IFont> availableFonts = GetAvailableFonts();
        if (availableFonts.Count == 0)
        {
            Console.WriteLine("No fonts available. Keeping current font.");
        }
        else
        {
            Console.WriteLine("Available Fonts:");
            for (int i = 0; i < availableFonts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableFonts[i].Name}");
            }

            int fontChoice = GetInputInRange("Enter the number of the desired font (or Enter to keep current font): ", 1, availableFonts.Count, true);
            if (fontChoice != -1)
            {
                templateBuilder.SetFont(availableFonts[fontChoice - 1]);
            }
        }

        Console.Write($"Color ({template.Color}): ");
        string newColorInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(newColorInput))
        {
            if (Enum.TryParse(newColorInput, out ConsoleColor newColor))
            {
                templateBuilder.SetColor(newColor);
            }
        }

        Console.Write($"Blinking ({(template.Blinking ? "Y" : "N")}): ");
        string newBlinkingInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(newBlinkingInput))
        {
            templateBuilder.SetBlinking(newBlinkingInput.ToUpper() == "Y");
        }

        TextTemplate updatedTemplate = templateBuilder.Build();

        // Update the template with the new values
        template.Name = updatedTemplate.Name;
        template.Font = updatedTemplate.Font;
        template.Color = updatedTemplate.Color;
        template.Blinking = updatedTemplate.Blinking;

        Console.WriteLine("Template updated successfully.");
    }

    public void DeleteTemplate()
    {
        Console.WriteLine("=== Delete Template ===");
        Console.Write("Enter template name: ");
        string templateName = Console.ReadLine();

        TextTemplate template = _templates.Find(t => t.Name == templateName);
        if (template == null)
        {
            Console.WriteLine("Template not found.");
            return;
        }

        _templates.Remove(template);

        Console.WriteLine("Template deleted successfully.");
    }

    public void DisplayTemplates()
    {
        Console.WriteLine("=== Templates ===");
        foreach (TextTemplate template in _templates)
        {
            template.Display();
            Console.WriteLine();
        }
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
    
    private int GetInputInRange(string prompt, int minValue, int maxValue, bool allowEmptyInput = false)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                if (allowEmptyInput)
                {
                    return -1;
                }
                else
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }
            }

            if (int.TryParse(input, out int value))
            {
                if (value >= minValue && value <= maxValue)
                {
                    return value;
                }
            }

            Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}.");
        }
    }
}