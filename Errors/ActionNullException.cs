namespace SLCore.Errors;

public struct ActionNullExceptionOptions
{
    public static string OnUsing = "找不到所输入指令对应的Action实例，请联系该命令的作者以寻求帮助";
    public static string OnChecking = "注册命令时发现该命令的Action为Null，出错的命令Id: ";
}

public class ActionNullException : Exception
{
    public ActionNullException(string content, string id = "")
        : base(content)
    {
    }
}