using TickerText.DataStorage;
using TickerText.Menu;
using TickerText.Templates;

namespace TickerText;

public class Program
{
    public static readonly TemplateManager TemplateManager = new TemplateManager();

    public static readonly MenuManager MenuManager = new MenuManager();

    public static string ConfigFilePath = "TickerConfig.txt";
    
    public static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            ConfigFilePath = args[0];
        }

        MenuManager.Start();
    }
}
