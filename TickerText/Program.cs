﻿using TickerText.Menu;
using TickerText.Templates;
using TickerText.Text;

namespace TickerText;

public class Program
{
    public static readonly TemplateManager TemplateManager = new TemplateManager();

    public static readonly TextManager TextManager = new TextManager();
    
    public static readonly MenuManager MenuManager = new MenuManager();

    public static void Main(string[] args)
    {
        MenuManager.Start();
    }
}
