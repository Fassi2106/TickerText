using TickerText.Text.Fonts;

namespace TickerText.Templates;

public class TextTemplateBuilder
{
    private string _name;
    private IFont? _font;
    private ConsoleColor _color;
    private bool _blinking;

    public TextTemplateBuilder()
    {
        _name = "";
        _font = null;
        _color = ConsoleColor.White;
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

        return new TextTemplate(_name, _font, _color, _blinking);
    }
}