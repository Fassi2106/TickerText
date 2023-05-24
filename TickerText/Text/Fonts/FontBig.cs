

namespace TickerText.Text.Fonts;

public class FontBig : IFont
{
    public string Name { get; set; } = "Big";
    
    private static Dictionary<char, string> Characters { get; set; } 
        = new();

    public FontBig()
    {
        AddCharacter('a', Font_Big.FontBig__a.Char());
        AddCharacter('b', Font_Big.FontBig__b.Char());
        AddCharacter('c', Font_Big.FontBig__c.Char());
        AddCharacter('d', Font_Big.FontBig__d.Char());
        AddCharacter('e', Font_Big.FontBig__e.Char());
        AddCharacter('f', Font_Big.FontBig__f.Char());
        AddCharacter('g', Font_Big.FontBig__g.Char());
        AddCharacter('h', Font_Big.FontBig__h.Char());
        AddCharacter('i', Font_Big.FontBig__i.Char());
        AddCharacter('j', Font_Big.FontBig__j.Char());
        AddCharacter('k', Font_Big.FontBig__k.Char());
        AddCharacter('l', Font_Big.FontBig__l.Char());
        AddCharacter('m', Font_Big.FontBig__m.Char());
        AddCharacter('n', Font_Big.FontBig__n.Char());
        AddCharacter('o', Font_Big.FontBig__o.Char());
        AddCharacter('p', Font_Big.FontBig__p.Char());
        AddCharacter('q', Font_Big.FontBig__q.Char());
        AddCharacter('r', Font_Big.FontBig__r.Char());
        AddCharacter('s', Font_Big.FontBig__s.Char());
        AddCharacter('t', Font_Big.FontBig__t.Char());
        AddCharacter('u', Font_Big.FontBig__u.Char());
        AddCharacter('v', Font_Big.FontBig__v.Char());
        AddCharacter('w', Font_Big.FontBig__w.Char());
        AddCharacter('x', Font_Big.FontBig__x.Char());
        AddCharacter('y', Font_Big.FontBig__y.Char());
        AddCharacter('z', Font_Big.FontBig__z.Char());
        
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