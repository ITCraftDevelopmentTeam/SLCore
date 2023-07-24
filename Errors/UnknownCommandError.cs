namespace SLCore.Errors;

public class UnknownCommandError : Exception
{
    private static string content = "输入了未知的命令, 您的输入: ";

    public UnknownCommandError(string cmd)
        : base(content + cmd)
    {
    }
}