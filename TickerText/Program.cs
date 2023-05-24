using TickerText.Menu;
using TickerText.Templates;

namespace TickerText;

public class Program
{
    public static readonly TemplateManager TemplateManager = new TemplateManager();

    public static readonly MenuManager MenuManager = new MenuManager();
    
    public static async Task Main(string[] args)
    {
        MenuManager.Start();
    }
}
