namespace SLCore.Utils;

public static class SLOutput
{
    public static void Print(string? text, ConsoleColor? color = null)
    {
        if (!color.HasValue)
        {
            Console.WriteLine(text);
            return;
        }
        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color.Value;
        Console.WriteLine(text);
        Console.ForegroundColor = previousColor;
    }

    [Obsolete("不如放到 launcher 里面去")]
    public static void Prompt()
    {
        Console.Write("launcher >> ");
    }
}