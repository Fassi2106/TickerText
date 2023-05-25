using System.Reflection;

namespace TickerText.Text.Fonts;

public static class FontHelper
{
    public static IFont GetFontByName(string name)
    {
        return GetAvailableFonts().First(font => font.Name == name);
    }
    
    public static List<IFont> GetAvailableFonts()
    {
        List<IFont> availableFonts = new List<IFont>();

        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();

        foreach (Type type in types)
        {
            if (typeof(IFont).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            {
                IFont font = (IFont)Activator.CreateInstance(type);
                availableFonts.Add(font);
            }
        }

        return availableFonts;
    }
}