using TickerText.Templates;
using TickerText.Text.Fonts;

namespace TickerText.Text;

public static class AsciiArtGenerator
{
    public static string[] GenerateAsciiArt(string text, TextTemplate textTemplate)
    {
        var result = new string[DetermineHeight(text, textTemplate.Font)-1];
        
        foreach (var _char in text)
        {
            var asciiChar = textTemplate.Font.GetCharacter(_char).Split(Environment.NewLine);

            for (int i = 1; i < asciiChar.Length; i++)
            {
                result[i-1] += asciiChar[i];
            }
        }

        return result;
    }

    private static int DetermineHeight(string text, IFont font)
    {
        var result = 1;
        
        foreach (var _char in text)
        {
            var fontHeight = font.GetCharacter(_char).Split(Environment.NewLine).Length;

            if (fontHeight > result)
            {
                result = fontHeight;
            }
        }

        return result;
    }
}