using TickerText.Templates;

namespace TickerText.Menu;

public class TemplateMenu : IMenu
{
    private TemplateManager templateManager;

    public TemplateMenu()
    {
        templateManager = new TemplateManager();
    }

    public void Show()
    {
        Console.WriteLine("=== Template Menu ===");
        Console.WriteLine("1. Template erstellen");
        Console.WriteLine("2. Template bearbeiten");
        Console.WriteLine("3. Template löschen");
        Console.WriteLine("4. Templates anzeigen");
        Console.WriteLine("5. Zurück zum Hauptmenü");
    }

    public void HandleInput()
    {
        int choice = GetInput();
        switch (choice)
        {
            case 1:
                templateManager.CreateTemplate();
                break;
            case 2:
                templateManager.EditTemplate();
                break;
            case 3:
                templateManager.DeleteTemplate();
                break;
            case 4:
                templateManager.DisplayTemplates();
                break;
            case 5:
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                mainMenu.HandleInput();
                break;
            default:
                Console.WriteLine("Ungültige Eingabe!");
                HandleInput();
                break;
        }
    }

    private int GetInput()
    {
        Console.Write("Auswahl: ");
        return int.Parse(Console.ReadLine());
    }
}