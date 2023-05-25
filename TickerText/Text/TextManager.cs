using TickerText.DataStorage;
using TickerText.Menu;

namespace TickerText.Text;

public class TextManager
{
    private List<string> _texts = new List<string>();

    private string _configFilePath = "Texts.txt";
    
    public TextManager()
    {
        
    }

    public void DisplayTexts()
    {
        Console.WriteLine("=== Texts ===");

        foreach (var text in GetTexts())
        {
            Console.WriteLine(text);

            Console.WriteLine();
        }
    }
    
    public void CreateText()
    {
        Console.WriteLine("=== Create Text ===");

        var stringInputManager = new InputManager<string>("Text: ");
        
        AddText(stringInputManager.ReceiveInput());
        
        Console.WriteLine("Text created successfully.");
    }

    public void EditText()
    {
        Console.WriteLine("=== Edit Text ===");
        
        var availableTexts = GetTexts();
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

        var oldText = availableTexts[textSelection - 1];

        var stringInputManager = new InputManager<string>("Enter new text: ");
        
        UpdateText(oldText, stringInputManager.ReceiveInput());
        
        Console.WriteLine("Text updated successfully.");
    }
    
    public void DeleteText()
    {
        Console.WriteLine("=== Delete Text ===");

        var availableTexts = GetTexts();
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
        
        RemoveText(availableTexts[textSelection-1]);
        
        Console.WriteLine("Text deleted successfully.");
    }

    private void RemoveText(string text)
    {
        _texts.Remove(text);
        
        var storageProvider = new FileStorageProvider(_configFilePath, typeof(List<string>));
        
        storageProvider.SaveData(_texts);
    }
    
    private void AddText(string text)
    {
        _texts.Add(text);
        
        var storageProvider = new FileStorageProvider(_configFilePath, typeof(List<string>));
        
        storageProvider.SaveData(_texts);
    }

    private void UpdateText(string oldText, string newText)
    {
        var index = _texts.FindIndex(t => t == oldText);

        _texts[index] = newText;
        
        var storageProvider = new FileStorageProvider(_configFilePath, typeof(List<string>));

        storageProvider.SaveData(_texts);
    }
    
    public List<string> GetTexts()
    {
        var storageProvider = new FileStorageProvider(_configFilePath, typeof(List<string>));

        _texts = (List<string>)storageProvider.LoadData();

        return _texts;
    }
}