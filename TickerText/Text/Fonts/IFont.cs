namespace TickerText.Text.Fonts;

public interface IFont
{
    string Name { get; set; }
    
    string GetCharacter(char character);
}