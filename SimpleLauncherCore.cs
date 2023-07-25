using MinecraftLaunch.Modules.Toolkits;
using SLCore.Commands;
using SLCore.Commands.Prefabs;
using SLCore.CoreInfo;

namespace SLCore;

public sealed class SimpleLauncherCore : IDisposable
{
    public GameCoreToolkit CoreToolKit { get; }
    public CommandPool CommandPool { get; }
    public SLCoreInfo CoreInfo { get; }

    public SimpleLauncherCore(ILauncher launcher)
    {
        this.CoreToolKit = new GameCoreToolkit(".minecraft");
        this.CommandPool = new CommandPool(this);
        this.CoreInfo = new SLCoreInfo(launcher);

        this.CommandPool.Register(new HelpCommand(this));
        this.CommandPool.Register(new VersionCommand(this));
        this.CommandPool.Register(new ExitCommand(launcher));
    }

    public void Dispose()
    {
        // TODO: 需要把插件 Dispose 了
    }
}