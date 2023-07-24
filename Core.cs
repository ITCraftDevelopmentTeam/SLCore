using MinecraftLaunch.Modules.Toolkits;

namespace SLCore;

public class Core
{
    public static GameCoreToolkit? CoreToolKit = null;

    public static void InitCore()
    {
        CoreToolKit = new GameCoreToolkit(".minecraft");
        Command.CommandPool.InitPool();
    }
}