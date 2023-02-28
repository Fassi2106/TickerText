namespace TickerText;

public class MainMenu : Menu,IMenu
{
    public MenuType StartMenu()
    {
        while (true)
        {
            Console.WriteLine("Bitte wählen Sie eine Option:");
            Console.WriteLine("1. Texteingabe");
            Console.WriteLine("2. Schriftart auswählen");
            Console.WriteLine("3. Ansicht bearbeiten");

            var input = WaitForInput();

            switch (input)
            {
                case "1":

                    Console.WriteLine("Sie haben Texteingabe gewählt.");
                    break;
                case "2":
                    Console.WriteLine("Sie haben Schriftart auswählen gewählt.");
                    break;
                case "3":
                    return MenuType.DisplaySettings;
                    break;
            }
        }
    }
}
