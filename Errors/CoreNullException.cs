namespace SLCore.Errors;

public class CoreNullException: Exception
{
    private static string content = "使用CoreToolKit的时候未初始化或者指定了一个空CoreToolKit，您可以通过提交issue的方式来向作者反馈";

    public CoreNullException()
        : base(content)
    {
    }
}