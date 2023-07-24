namespace SLCore.Errors;

public struct CommandArgumentErrorOptions
{
    public static string TooManyParametersError = "对于该命令输入了过多的参数，请检查帮助手册并对该命令输入正确个数的参数";
    public static string WrongParameterError = "所输入的参数与该命令要求的不符，请查阅帮助列表以获取帮助";
    public static string MissingParameterError = "对于该命令输入了过少的参数，请检查帮助手册并对该命令输入正确个数的参数";
}

public class CommandArgumentError : Exception
{
    public CommandArgumentError(string detail)
        : base(detail)
    {
    }
}