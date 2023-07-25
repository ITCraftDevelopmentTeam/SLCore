namespace SLCore.Command;

public class ArgumentManager
{
    public static string MergeArgs(string[] args)
    {
        string ret = new string((ReadOnlySpan<char>)"");
        if (args != null)
        {
            foreach (var seg in args)
            {
                ret += seg + " ";
            }

            ret = ret.Substring(0, ret.Length - 1);
        }
        return ret;
    }

    public static string[] ConsumeHead(string[] args)
    {
        return args.Skip(1).ToArray();
    }
}