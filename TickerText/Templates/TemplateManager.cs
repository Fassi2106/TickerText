using TickerText.DataStorage;
using TickerText.Menu;
using TickerText.Text.Fonts;

namespace TickerText.Templates;

public class TemplateManager
{
    private List<TextTemplate> _templates;

    private TextTemplate _selectedTemplate;

    private string _configFilePath = "TickerConfig.txt";
    
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
        return new TextTemplate("Default", new FontBig().Name, ConsoleColor.White, 100, false);
    }

    public TextTemplate GetSelectedTemplate()
    {
        return _selectedTemplate;
    }

    public void SetSelectedTemplate(TextTemplate template)
    {
        _selectedTemplate = template;
    }
    
    public void DisplayTemplates()
    {
        Console.WriteLine("=== Templates ===");
        
        foreach (var template in GetTemplates())
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

        var availableFonts = FontHelper.GetAvailableFonts();
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

        templateBuilder.SetFont(availableFonts[fontSelection - 1].Name);

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

        AddTemplate(template);

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

            template = GetTemplates().FirstOrDefault(t => t.Name.Equals(templateSelection));

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
        
        var availableFonts = FontHelper.GetAvailableFonts();
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

        templateBuilder.SetFont(availableFonts[fontSelection - 1].Name);
        

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
        
        var boolInputManager = new InputManager<bool>("Blinking: ", true);

        templateBuilder.SetBlinking(boolInputManager.ReceiveInput());
        
        var updatedTemplate = templateBuilder.Build();
        
        UpdateTemplate(template.Name, updatedTemplate);

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

            template = GetTemplates().FirstOrDefault(t => t.Name.Equals(templateSelection));

            if (template == null)
            {
                Console.WriteLine("Template not found");
            }   
        }

        RemoveTemplate(template);

        Console.WriteLine("Template deleted successfully.");
    }

    public void RemoveTemplate(TextTemplate template)
    {
        _templates.RemoveAll(t => t.Name.Equals(template.Name));
        
        var storageProvider = new FileStorageProvider(_configFilePath, typeof(List<TextTemplate>));
            
        storageProvider.SaveData(_templates);
    }

    public void AddTemplate(TextTemplate template)
    {
        _templates.Add(template);
        
        var storageProvider = new FileStorageProvider(_configFilePath, typeof(List<TextTemplate>));
            
        storageProvider.SaveData(_templates);
    }

    public void UpdateTemplate(string name, TextTemplate newTemplate)
    {
        var template = _templates.First(t => t.Name.Equals(name));
        
        template.Name = newTemplate.Name;
        template.FontName = newTemplate.FontName;
        template.Color = newTemplate.Color;
        template.SpeedInMillis = newTemplate.SpeedInMillis;
        template.Blinking = newTemplate.Blinking;
        
        var storageProvider = new FileStorageProvider(_configFilePath, typeof(List<TextTemplate>));
            
        storageProvider.SaveData(_templates);
    }

    public List<TextTemplate> GetTemplates()
    {
        var storageProvider = new FileStorageProvider(_configFilePath, typeof(List<TextTemplate>));

        _templates = (List<TextTemplate>)storageProvider.LoadData(new List<TextTemplate>());

        return _templates;
    }
}