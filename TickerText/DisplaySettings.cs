namespace TickerText;

public class DisplaySettings : Menu, IMenu
{
    public MenuType StartMenu()
    {
        while (true)
        {
            Console.WriteLine("Was wollen Sie an Ihrer Ansicht ändern?");
            Console.WriteLine("1. Speed");
            Console.WriteLine("2. Fontcolor");
            Console.WriteLine("3. Finish for next Rotation");
            Console.WriteLine("4. Direction");
            Console.WriteLine("5. Back");

            var input = WaitForInput();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Sie haben Speed gewählt.");
                    break;
                case "2":
                    Console.WriteLine("Sie haben Fontcolor gewählt.");
                    break;
                case "3":
                    Console.WriteLine("Sie haben Finish for next Rotation gewählt.");
                    break;
                case "4":
                    Console.WriteLine("Sie haben Direction gewählt.");
                    break;
                case "5":
                    return MenuType.MainMenu;
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie eine Option von 1 bis 5.");
                    break;
            }
        }
    }
}