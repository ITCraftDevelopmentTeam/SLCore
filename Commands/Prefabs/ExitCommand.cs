using SLCore.Utils;

namespace SLCore.Commands.Prefabs;
internal sealed class ExitCommand : ISLCommand
{
    public string Id { get; } = "simplelauncher:exit";

    public IEnumerable<string> Aliases { get; } = new string[]
    {
        "exit", "quit", "q"
    };

    public string HelpContent => $"exit | quit | q: 退出启动器{Environment.NewLine}";

    public Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        SLOutput.Print("正在退出程序...");

        // TODO: 最好不要直接用 Environment.Exit(0); 。可以在 core 里面加一个 close 方法，并且具体如何关闭由 launcher 处理。
        Environment.Exit(0);
        return Task.FromResult<ISLCommand?>(null);
    }
}
