namespace TickerText.Text.Fonts;

public class FontPuffy : IFont
{
    public string Name { get; set; } = "Puffy";
    
    private static Dictionary<char, string> Characters { get; set; } 
        = new();

    public FontPuffy()
    {
        AddCharacter('0', Font_Puffy.FontPuffy_0.Char());
        AddCharacter('1', Font_Puffy.FontPuffy_1.Char());
        AddCharacter('2', Font_Puffy.FontPuffy_2.Char());
        AddCharacter('3', Font_Puffy.FontPuffy_3.Char());
        AddCharacter('4', Font_Puffy.FontPuffy_4.Char());
        AddCharacter('5', Font_Puffy.FontPuffy_5.Char());
        AddCharacter('6', Font_Puffy.FontPuffy_6.Char());
        AddCharacter('7', Font_Puffy.FontPuffy_7.Char());
        AddCharacter('8', Font_Puffy.FontPuffy_8.Char());
        AddCharacter('9', Font_Puffy.FontPuffy_9.Char());
        
        AddCharacter('a', Font_Puffy.FontPuffy__a.Char());
        AddCharacter('b', Font_Puffy.FontPuffy__b.Char());
        AddCharacter('c', Font_Puffy.FontPuffy__c.Char());
        AddCharacter('d', Font_Puffy.FontPuffy__d.Char());
        AddCharacter('e', Font_Puffy.FontPuffy__e.Char());
        AddCharacter('f', Font_Puffy.FontPuffy__f.Char());
        AddCharacter('g', Font_Puffy.FontPuffy__g.Char());
        AddCharacter('h', Font_Puffy.FontPuffy__h.Char());
        AddCharacter('i', Font_Puffy.FontPuffy__i.Char());
        AddCharacter('j', Font_Puffy.FontPuffy__j.Char());
        AddCharacter('k', Font_Puffy.FontPuffy__k.Char());
        AddCharacter('l', Font_Puffy.FontPuffy__l.Char());
        AddCharacter('m', Font_Puffy.FontPuffy__m.Char());
        AddCharacter('n', Font_Puffy.FontPuffy__n.Char());
        AddCharacter('o', Font_Puffy.FontPuffy__o.Char());
        AddCharacter('p', Font_Puffy.FontPuffy__p.Char());
        AddCharacter('q', Font_Puffy.FontPuffy__q.Char());
        AddCharacter('r', Font_Puffy.FontPuffy__r.Char());
        AddCharacter('s', Font_Puffy.FontPuffy__s.Char());
        AddCharacter('t', Font_Puffy.FontPuffy__t.Char());
        AddCharacter('u', Font_Puffy.FontPuffy__u.Char());
        AddCharacter('v', Font_Puffy.FontPuffy__v.Char());
        AddCharacter('w', Font_Puffy.FontPuffy__w.Char());
        AddCharacter('x', Font_Puffy.FontPuffy__x.Char());
        AddCharacter('y', Font_Puffy.FontPuffy__y.Char());
        AddCharacter('z', Font_Puffy.FontPuffy__z.Char());
        
        AddCharacter('A', Font_Puffy.FontPuffy_A.Char());
        AddCharacter('B', Font_Puffy.FontPuffy_B.Char());
        AddCharacter('C', Font_Puffy.FontPuffy_C.Char());
        AddCharacter('D', Font_Puffy.FontPuffy_D.Char());
        AddCharacter('E', Font_Puffy.FontPuffy_E.Char());
        AddCharacter('F', Font_Puffy.FontPuffy_F.Char());
        AddCharacter('G', Font_Puffy.FontPuffy_G.Char());
        AddCharacter('H', Font_Puffy.FontPuffy_H.Char());
        AddCharacter('I', Font_Puffy.FontPuffy_I.Char());
        AddCharacter('J', Font_Puffy.FontPuffy_J.Char());
        AddCharacter('K', Font_Puffy.FontPuffy_K.Char());
        AddCharacter('L', Font_Puffy.FontPuffy_L.Char());
        AddCharacter('M', Font_Puffy.FontPuffy_M.Char());
        AddCharacter('N', Font_Puffy.FontPuffy_N.Char());
        AddCharacter('O', Font_Puffy.FontPuffy_O.Char());
        AddCharacter('P', Font_Puffy.FontPuffy_P.Char());
        AddCharacter('Q', Font_Puffy.FontPuffy_Q.Char());
        AddCharacter('R', Font_Puffy.FontPuffy_R.Char());
        AddCharacter('S', Font_Puffy.FontPuffy_S.Char());
        AddCharacter('T', Font_Puffy.FontPuffy_T.Char());
        AddCharacter('U', Font_Puffy.FontPuffy_U.Char());
        AddCharacter('V', Font_Puffy.FontPuffy_V.Char());
        AddCharacter('W', Font_Puffy.FontPuffy_W.Char());
        AddCharacter('X', Font_Puffy.FontPuffy_X.Char());
        AddCharacter('Y', Font_Puffy.FontPuffy_Y.Char());
        AddCharacter('Z', Font_Puffy.FontPuffy_Z.Char());
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