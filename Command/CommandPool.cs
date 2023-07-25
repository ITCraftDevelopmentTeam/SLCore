using System.Collections;
using SLCore.Command.SLCMDPrefabs;
using SLCore.Errors;

namespace SLCore.Command;

public class CommandPool
{
    public static ArrayList? Pool = null;

    public static void InitPool()
    {
        Pool = new ArrayList();
        SLRegister.register(Prefabs.CMD_HELP);
        SLRegister.register(Prefabs.CMD_VERSION);
        SLRegister.register(Prefabs.CMD_EXIT);
    }
}

public class SLRegister
{
    public static void register(SLCommand slCommand)
    {
        // 对command是否合法进行排查
        if (slCommand.GetDefaultId() == null)
            throw new CommandIdNullException();
        
        if (slCommand.HelpContent == null)
            throw new HelpContentNullException(slCommand.GetDefaultId().GetText());

        if (slCommand.GetAction() == null)
            throw new ActionNullException(ActionNullExceptionOptions.OnChecking, slCommand.GetDefaultId().GetText());

        CommandPool.Pool?.Add(slCommand);
    }
}