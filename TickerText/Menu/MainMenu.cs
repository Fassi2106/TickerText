namespace TickerText.Menu;

public class MainMenu : IMenu
{
    public void Show()
    {
        Console.WriteLine("=== Hauptmenü ===");
        Console.WriteLine("1. Optionen");
        Console.WriteLine("2. Aktionen");
        Console.WriteLine("3. Templates");
        Console.WriteLine("4. Beenden");
    }

    public void HandleInput()
    {
        int choice = GetInput();
        switch (choice)
        {
            case 1:
                OptionMenu optionMenu = new OptionMenu();
                optionMenu.Show();
                optionMenu.HandleInput();
                break;
            case 2:
                ActionMenu actionMenu = new ActionMenu();
                actionMenu.Show();
                actionMenu.HandleInput();
                break;
            case 3:
                TemplateMenu templateMenu = new TemplateMenu();
                templateMenu.Show();
                templateMenu.HandleInput();
                break;
            case 4:
                Console.WriteLine("Das Programm wird beendet.");
                Environment.Exit(0);
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