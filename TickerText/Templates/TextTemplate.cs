using System.Xml.Serialization;
using TickerText.Text.Fonts;

namespace TickerText.Templates;

public class TextTemplate
{
    public string Name { get; set; }
    
    public string FontName { get; set; }
    
    public ConsoleColor Color { get; set; }
    
    public int SpeedInMillis { get; set; }
    
    public bool Blinking { get; set; }

    public TextTemplate(){}
    
    public TextTemplate(string name, string fontName, ConsoleColor color, int speedInMillis, bool blinking)
    {
        Name = name;
        FontName = fontName;
        Color = color;
        SpeedInMillis = speedInMillis;
        Blinking = blinking;
    }
    
    public void Display()
    {
        Console.WriteLine($"=== {Name} ===");
        Console.WriteLine($"Font: {FontName}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Speed: {SpeedInMillis}");
        Console.WriteLine($"Blinking: {(Blinking ? "Yes" : "No")}");
    }
}