namespace SLCore.Utils;

using System.Drawing;

public class SLOutput
{
    public static void Print(string text, ConsoleColor color)
    {
        var _default = Console.ForegroundColor; 
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = _default;
    }

    public static void Prompt()
    {
        Console.Out.Write("launcher >> ");
    }
}