namespace SLCore.Errors;

public class CommandIdNullException : Exception
{
    private static string content = "有命令的Id为空，请联系命令作者或者前往启动器网站提交issue进行反馈";

    public CommandIdNullException()
        : base(content)
    {
    }
}