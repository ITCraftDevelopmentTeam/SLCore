using SLCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLCore.Commands.Prefabs;
internal sealed class VersionCommand : ISLCommand
{
    private readonly SimpleLauncherCore core;
    public VersionCommand(SimpleLauncherCore core)
    {
        this.core = core;
    }
    public void Dispose()
    {
        return;
    }

    public string Id { get; } = "simplelauncher:version";

    public IEnumerable<string> Aliases { get; } = new string[]
    {
        // TODO: 这个大小写就很灵性
        "version", "ver", "Version"
    };

    public string HelpContent => $"version | ver | Version: 查看启动器及其核心版本{Environment.NewLine}";

    public Task<ISLCommand?> Execute(IEnumerable<string> args)
    {
        SLOutput.Print("当前核心版本: " + core.CoreInfo.CoreVersion, ConsoleColor.Green);
        SLOutput.Print("当前启动器版本: " + core.CoreInfo.LauncherVersion, ConsoleColor.Green);
        SLOutput.Print("程序使用许可证: " + core.CoreInfo.License, ConsoleColor.Cyan);
        return Task.FromResult<ISLCommand?>(null);
    }
}
