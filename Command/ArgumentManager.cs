namespace SLCore.Command;

public class ArgumentManager
{
    public static string MergeArgs(string[]? segs)
    {
        string ret = new string((ReadOnlySpan<char>)"");
        if (segs != null)
        {
            foreach (var seg in segs)
            {
                ret += seg + " ";
            }

            ret = ret.Substring(0, ret.Length - 1);
        }
        return ret;
    }

    public static string[]? ConsumeHead(string[]? segs)
    {
        return segs?.Skip(1).ToArray();
    }
}