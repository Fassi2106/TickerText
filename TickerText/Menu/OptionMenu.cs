namespace TickerText.Menu;

public class OptionMenu : IMenu
{
    public void Show()
    {
        Console.WriteLine("=== Optionenmenü ===");
        Console.WriteLine("1. Schnelligkeit ändern");
        Console.WriteLine("2. Größe ändern");
        Console.WriteLine("3. Farbe ändern");
        Console.WriteLine("4. Zurück zum Hauptmenü");
    }

    public void HandleInput()
    {
        int choice = GetInput();
        switch (choice)
        {
            case 1:
                // Logik für Schnelligkeit ändern
                break;
            case 2:
                // Logik für Größe ändern
                break;
            case 3:
                // Logik für Farbe ändern
                break;
            case 4:
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