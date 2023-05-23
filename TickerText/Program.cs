using TickerText.Menu;
using TickerText.Text.Fonts.FontBig;

namespace TickerText;

public class Program
{
    public static async Task Main(string[] args)
    {
        MenuManager menuManager = new MenuManager();
        menuManager.Start();
    }
}
