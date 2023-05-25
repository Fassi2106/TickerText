using TickerText.Text.Fonts;

namespace TickerText.Templates;

public class TextTemplate
{
    public string Name { get; set; }
    
    public IFont Font { get; set; }
    
    public ConsoleColor Color { get; set; }
    
    public int SpeedInMillis { get; set; }
    
    public bool Blinking { get; set; }

    public TextTemplate(string name, IFont font, ConsoleColor color, int speedInMillis, bool blinking)
    {
        Name = name;
        Font = font;
        Color = color;
        SpeedInMillis = speedInMillis;
        Blinking = blinking;
    }
    
    public void Display()
    {
        Console.WriteLine($"=== {Name} ===");
        Console.WriteLine($"Font: {Font.Name}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Speed: {SpeedInMillis}");
        Console.WriteLine($"Blinking: {(Blinking ? "Yes" : "No")}");
    }
}