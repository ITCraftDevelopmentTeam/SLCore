using MinecraftLaunch.Modules.Toolkits;
using SLCore.Commands;
using SLCore.CoreInfo;
using SLCore.Utils;

namespace SLCore;

public sealed class SimpleLauncherCore : IDisposable
{
    public GameCoreToolkit CoreToolKit { get; }
    public CommandPool CommandPool { get; }
    public SLCoreInfo CoreInfo { get; }
    public SimpleLauncherCore()
    {
        this.CoreToolKit = new GameCoreToolkit(".minecraft");
        this.CommandPool = new CommandPool(this);
        this.CoreInfo = new SLCoreInfo();
    }

    public void Dispose()
    {
        // TODO: 需要把插件 Dispose 了
    }
}