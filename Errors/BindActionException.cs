namespace SLCore.Errors;

public struct BindActionExceptionOptions
{
    public static string UnMatchedType = "在给命令绑定Action的时候忽略了该命令Action的类型为\"Seg\"";
}

public class BindActionException: Exception
{
    public BindActionException(string content)
        : base(content)
    {
    }
}