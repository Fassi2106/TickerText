namespace TickerText.Text.Fonts;

public class FontSmall : IFont
{
    public string Name { get; set; } = "Small";
    
    private static Dictionary<char, string> Characters { get; set; } 
        = new();

    public FontSmall()
    {
        AddCharacter('0', Font_Small.FontSmall_0.Char());
        AddCharacter('1', Font_Small.FontSmall_1.Char());
        AddCharacter('2', Font_Small.FontSmall_2.Char());
        AddCharacter('3', Font_Small.FontSmall_3.Char());
        AddCharacter('4', Font_Small.FontSmall_4.Char());
        AddCharacter('5', Font_Small.FontSmall_5.Char());
        AddCharacter('6', Font_Small.FontSmall_6.Char());
        AddCharacter('7', Font_Small.FontSmall_7.Char());
        AddCharacter('8', Font_Small.FontSmall_8.Char());
        AddCharacter('9', Font_Small.FontSmall_9.Char());
        
        AddCharacter('a', Font_Small.FontSmall__a.Char());
        AddCharacter('b', Font_Small.FontSmall__b.Char());
        AddCharacter('c', Font_Small.FontSmall__c.Char());
        AddCharacter('d', Font_Small.FontSmall__d.Char());
        AddCharacter('e', Font_Small.FontSmall__e.Char());
        AddCharacter('f', Font_Small.FontSmall__f.Char());
        AddCharacter('g', Font_Small.FontSmall__g.Char());
        AddCharacter('h', Font_Small.FontSmall__h.Char());
        AddCharacter('i', Font_Small.FontSmall__i.Char());
        AddCharacter('j', Font_Small.FontSmall__j.Char());
        AddCharacter('k', Font_Small.FontSmall__k.Char());
        AddCharacter('l', Font_Small.FontSmall__l.Char());
        AddCharacter('m', Font_Small.FontSmall__m.Char());
        AddCharacter('n', Font_Small.FontSmall__n.Char());
        AddCharacter('o', Font_Small.FontSmall__o.Char());
        AddCharacter('p', Font_Small.FontSmall__p.Char());
        AddCharacter('q', Font_Small.FontSmall__q.Char());
        AddCharacter('r', Font_Small.FontSmall__r.Char());
        AddCharacter('s', Font_Small.FontSmall__s.Char());
        AddCharacter('t', Font_Small.FontSmall__t.Char());
        AddCharacter('u', Font_Small.FontSmall__u.Char());
        AddCharacter('v', Font_Small.FontSmall__v.Char());
        AddCharacter('w', Font_Small.FontSmall__w.Char());
        AddCharacter('x', Font_Small.FontSmall__x.Char());
        AddCharacter('y', Font_Small.FontSmall__y.Char());
        AddCharacter('z', Font_Small.FontSmall__z.Char());
        
        AddCharacter('A', Font_Small.FontSmall_A.Char());
        AddCharacter('B', Font_Small.FontSmall_B.Char());
        AddCharacter('C', Font_Small.FontSmall_C.Char());
        AddCharacter('D', Font_Small.FontSmall_D.Char());
        AddCharacter('E', Font_Small.FontSmall_E.Char());
        AddCharacter('F', Font_Small.FontSmall_F.Char());
        AddCharacter('G', Font_Small.FontSmall_G.Char());
        AddCharacter('H', Font_Small.FontSmall_H.Char());
        AddCharacter('I', Font_Small.FontSmall_I.Char());
        AddCharacter('J', Font_Small.FontSmall_J.Char());
        AddCharacter('K', Font_Small.FontSmall_K.Char());
        AddCharacter('L', Font_Small.FontSmall_L.Char());
        AddCharacter('M', Font_Small.FontSmall_M.Char());
        AddCharacter('N', Font_Small.FontSmall_N.Char());
        AddCharacter('O', Font_Small.FontSmall_O.Char());
        AddCharacter('P', Font_Small.FontSmall_P.Char());
        AddCharacter('Q', Font_Small.FontSmall_Q.Char());
        AddCharacter('R', Font_Small.FontSmall_R.Char());
        AddCharacter('S', Font_Small.FontSmall_S.Char());
        AddCharacter('T', Font_Small.FontSmall_T.Char());
        AddCharacter('U', Font_Small.FontSmall_U.Char());
        AddCharacter('V', Font_Small.FontSmall_V.Char());
        AddCharacter('W', Font_Small.FontSmall_W.Char());
        AddCharacter('X', Font_Small.FontSmall_X.Char());
        AddCharacter('Y', Font_Small.FontSmall_Y.Char());
        AddCharacter('Z', Font_Small.FontSmall_Z.Char());
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