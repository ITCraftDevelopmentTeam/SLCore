namespace SLCore.Errors;

public class HelpContentNullException : Exception
{
    private static string content = "命令的帮助文档为空, 命令Id: ";

    public HelpContentNullException(string id)
        : base(content + id)
    {
    }
}