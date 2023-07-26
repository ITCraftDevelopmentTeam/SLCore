using MinecraftLaunch.Modules;
using MinecraftLaunch.Modules.Models.Launch;
using SLCore.Commands;
using SLCore.Commands.Prefabs;
using SLCore.CoreInfo;

namespace SLCore;

public sealed class SimpleLauncherCore : IDisposable
{
    public GameCore CoreToolKit { get; }
    public SLCommandManager SlCommandManager { get; }
    public SLCoreInfo CoreInfo { get; }

    public SimpleLauncherCore(ILauncher launcher)
    {
        this.CoreToolKit = new GameCore();
        this.SlCommandManager = new SLCommandManager(this);
        this.CoreInfo = new SLCoreInfo(launcher);

        this.SlCommandManager.Register(new HelpCommand(this));
        this.SlCommandManager.Register(new VersionCommand(this));
        this.SlCommandManager.Register(new ExitCommand(launcher));
    }

    public void Dispose()
    {
        // TODO: 需要把插件 Dispose 了
    }
}