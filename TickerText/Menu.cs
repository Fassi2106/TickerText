namespace TickerText;

public class Menu
{

    public string WaitForInput()
    {
        var input = string.Empty;
        do
        {
            input = Console.ReadLine();
        } while (string.IsNullOrEmpty(input));

        return input;
    }
}