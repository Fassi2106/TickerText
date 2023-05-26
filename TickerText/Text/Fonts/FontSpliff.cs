namespace TickerText.Text.Fonts;

public class FontSpliff : IFont
{
    public string Name { get; set; } = "Spliff";
    
    private static Dictionary<char, string> Characters { get; set; } 
        = new();

    public FontSpliff()
    {
        AddCharacter('0', Font_Spliff.FontSpliff_0.Char());
        AddCharacter('1', Font_Spliff.FontSpliff_1.Char());
        AddCharacter('2', Font_Spliff.FontSpliff_2.Char());
        AddCharacter('3', Font_Spliff.FontSpliff_3.Char());
        AddCharacter('4', Font_Spliff.FontSpliff_4.Char());
        AddCharacter('5', Font_Spliff.FontSpliff_5.Char());
        AddCharacter('6', Font_Spliff.FontSpliff_6.Char());
        AddCharacter('7', Font_Spliff.FontSpliff_7.Char());
        AddCharacter('8', Font_Spliff.FontSpliff_8.Char());
        AddCharacter('9', Font_Spliff.FontSpliff_9.Char());

        AddCharacter('a', Font_Spliff.FontSpliff__a.Char());
        AddCharacter('b', Font_Spliff.FontSpliff__b.Char());
        AddCharacter('c', Font_Spliff.FontSpliff__c.Char());
        AddCharacter('d', Font_Spliff.FontSpliff__d.Char());
        AddCharacter('e', Font_Spliff.FontSpliff__e.Char());
        AddCharacter('f', Font_Spliff.FontSpliff__f.Char());
        AddCharacter('g', Font_Spliff.FontSpliff__g.Char());
        AddCharacter('h', Font_Spliff.FontSpliff__h.Char());
        AddCharacter('i', Font_Spliff.FontSpliff__i.Char());
        AddCharacter('j', Font_Spliff.FontSpliff__j.Char());
        AddCharacter('k', Font_Spliff.FontSpliff__k.Char());
        AddCharacter('l', Font_Spliff.FontSpliff__l.Char());
        AddCharacter('m', Font_Spliff.FontSpliff__m.Char());
        AddCharacter('n', Font_Spliff.FontSpliff__n.Char());
        AddCharacter('o', Font_Spliff.FontSpliff__o.Char());
        AddCharacter('p', Font_Spliff.FontSpliff__p.Char());
        AddCharacter('q', Font_Spliff.FontSpliff__q.Char());
        AddCharacter('r', Font_Spliff.FontSpliff__r.Char());
        AddCharacter('s', Font_Spliff.FontSpliff__s.Char());
        AddCharacter('t', Font_Spliff.FontSpliff__t.Char());
        AddCharacter('u', Font_Spliff.FontSpliff__u.Char());
        AddCharacter('v', Font_Spliff.FontSpliff__v.Char());
        AddCharacter('w', Font_Spliff.FontSpliff__w.Char());
        AddCharacter('x', Font_Spliff.FontSpliff__x.Char());
        AddCharacter('y', Font_Spliff.FontSpliff__y.Char());
        AddCharacter('z', Font_Spliff.FontSpliff__z.Char());
        
        AddCharacter('A', Font_Spliff.FontSpliff__a.Char());
        AddCharacter('B', Font_Spliff.FontSpliff__b.Char());
        AddCharacter('C', Font_Spliff.FontSpliff__c.Char());
        AddCharacter('D', Font_Spliff.FontSpliff__d.Char());
        AddCharacter('E', Font_Spliff.FontSpliff__e.Char());
        AddCharacter('F', Font_Spliff.FontSpliff__f.Char());
        AddCharacter('G', Font_Spliff.FontSpliff__g.Char());
        AddCharacter('H', Font_Spliff.FontSpliff__h.Char());
        AddCharacter('I', Font_Spliff.FontSpliff__i.Char());
        AddCharacter('J', Font_Spliff.FontSpliff__j.Char());
        AddCharacter('K', Font_Spliff.FontSpliff__k.Char());
        AddCharacter('L', Font_Spliff.FontSpliff__l.Char());
        AddCharacter('M', Font_Spliff.FontSpliff__m.Char());
        AddCharacter('N', Font_Spliff.FontSpliff__n.Char());
        AddCharacter('O', Font_Spliff.FontSpliff__o.Char());
        AddCharacter('P', Font_Spliff.FontSpliff__p.Char());
        AddCharacter('Q', Font_Spliff.FontSpliff__q.Char());
        AddCharacter('R', Font_Spliff.FontSpliff__r.Char());
        AddCharacter('S', Font_Spliff.FontSpliff__s.Char());
        AddCharacter('T', Font_Spliff.FontSpliff__t.Char());
        AddCharacter('U', Font_Spliff.FontSpliff__u.Char());
        AddCharacter('V', Font_Spliff.FontSpliff__v.Char());
        AddCharacter('W', Font_Spliff.FontSpliff__w.Char());
        AddCharacter('X', Font_Spliff.FontSpliff__x.Char());
        AddCharacter('Y', Font_Spliff.FontSpliff__y.Char());
        AddCharacter('Z', Font_Spliff.FontSpliff__z.Char());
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