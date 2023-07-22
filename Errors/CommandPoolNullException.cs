namespace SLCore.Errors;

public class CommandPoolNullException: Exception
{
    private static string content = "处理命令时发现命令池并未初始化，请前往项目github网站提交issue以反馈作者";

    public CommandPoolNullException()
        : base(content)
    {
    }
}