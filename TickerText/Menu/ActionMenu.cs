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
        Console.WriteLine("1. Run Text");
        Console.WriteLine("2. Back to Main Menu");
    }

    public void HandleInput()
    {
        int choice = GetInput();
        switch (choice)
        {
            case 1:
                RunText();
                break;
            case 2:
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                mainMenu.HandleInput();
                break;
            default:
                Console.WriteLine("Invalid input!");
                HandleInput();
                break;
        }
    }

    private int GetInput()
    {
        Console.Write("Enter your choice: ");
        return int.Parse(Console.ReadLine());
    }

    private void RunText()
    {
        Console.WriteLine("Enter the text to display: ");
        string text = Console.ReadLine();

        Console.Write(AsciiArtGenerator.GenerateAsciiArt(text, Program.TemplateManager.GetSelectedTemplate()));
    }
}