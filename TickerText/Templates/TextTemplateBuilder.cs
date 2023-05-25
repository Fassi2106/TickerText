using TickerText.Text.Fonts;

namespace TickerText.Templates;

public class TextTemplateBuilder
{
    private string _name;
    private IFont? _font;
    private ConsoleColor _color;
    private int _speedInMillis;
    private bool _blinking;

    public TextTemplateBuilder(TextTemplate template)
    {
        _name = template.Name;
        _font = template.Font;
        _color = template.Color;
        _speedInMillis = template.SpeedInMillis;
        _blinking = template.Blinking;
    }
    
    public TextTemplateBuilder()
    {
        _name = "";
        _font = null;
        _color = ConsoleColor.White;
        _speedInMillis = 100;
        _blinking = false;
    }

    public TextTemplateBuilder SetName(string name)
    {
        _name = name;
        
        return this;
    }

    public TextTemplateBuilder SetFont(IFont font)
    {
        _font = font;
        
        return this;
    }

    public TextTemplateBuilder SetColor(ConsoleColor color)
    {
        _color = color;
        
        return this;
    }

    public TextTemplateBuilder SetSpeed(int speedInMillis)
    {
        _speedInMillis = speedInMillis;

        return this;
    }

    public TextTemplateBuilder SetBlinking(bool blinking)
    {
        _blinking = blinking;
        
        return this;
    }

    public TextTemplate Build()
    {
        if (string.IsNullOrEmpty(_name))
        {
            throw new ArgumentException("A name must be set");
        }

        if (_font == null)
        {
            throw new ArgumentException("A font must be selected");
        }

        return new TextTemplate(_name, _font, _color, _speedInMillis, _blinking);
    }
}