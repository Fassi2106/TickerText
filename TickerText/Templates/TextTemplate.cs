using TickerText.Text.Fonts;

namespace TickerText.Templates;

public class TextTemplate
{
    public string Name { get; set; }
    public IFont Font { get; set; }
    public ConsoleColor Color { get; set; }
    public bool Blinking { get; set; }

    public TextTemplate(string name, IFont font, ConsoleColor color, bool blinking)
    {
        Name = name;
        Font = font;
        Color = color;
        Blinking = blinking;
    }
    
    public void Display()
    {
        Console.WriteLine("=== Text Template ===");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Font: {Font.Name}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Blinking: {(Blinking ? "Ja" : "Nein")}");
    }
}