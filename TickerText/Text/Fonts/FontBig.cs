

namespace TickerText.Text.Fonts;

public class FontBig : IFont
{
    public string Name { get; set; } = "Big";
    
    private static Dictionary<char, string> Characters { get; set; } 
        = new();

    public FontBig()
    {
        AddCharacter('A', Font_Big.FontBig_A.Char());
        AddCharacter('B', Font_Big.FontBig_B.Char());
        AddCharacter('C', Font_Big.FontBig_C.Char());
        AddCharacter('D', Font_Big.FontBig_D.Char());
        AddCharacter('E', Font_Big.FontBig_E.Char());
        AddCharacter('F', Font_Big.FontBig_F.Char());
        AddCharacter('G', Font_Big.FontBig_G.Char());
        AddCharacter('H', Font_Big.FontBig_H.Char());
        AddCharacter('I', Font_Big.FontBig_I.Char());
        AddCharacter('J', Font_Big.FontBig_J.Char());
        AddCharacter('K', Font_Big.FontBig_K.Char());
        AddCharacter('L', Font_Big.FontBig_L.Char());
        AddCharacter('M', Font_Big.FontBig_M.Char());
        AddCharacter('N', Font_Big.FontBig_N.Char());
        AddCharacter('O', Font_Big.FontBig_O.Char());
        AddCharacter('P', Font_Big.FontBig_P.Char());
        AddCharacter('Q', Font_Big.FontBig_Q.Char());
        AddCharacter('R', Font_Big.FontBig_R.Char());
        AddCharacter('S', Font_Big.FontBig_S.Char());
        AddCharacter('T', Font_Big.FontBig_T.Char());
        AddCharacter('U', Font_Big.FontBig_U.Char());
        AddCharacter('V', Font_Big.FontBig_V.Char());
        AddCharacter('W', Font_Big.FontBig_W.Char());
        AddCharacter('X', Font_Big.FontBig_X.Char());
        AddCharacter('Y', Font_Big.FontBig_Y.Char());
        AddCharacter('Z', Font_Big.FontBig_Z.Char());
    }
    
    private void AddCharacter(char character, string asciiChar)
    {
        Characters[character] = asciiChar;
    }

    public string GetCharacter(char character)
    {
        return Characters[character];
    }
}