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
    public static void register(CommandInstance command)
    {
        // 对command是否合法进行排查
        if (command.GetDefaultId() == null)
            throw new CommandIdNullException();
        
        if (command.HelpContent == null)
            throw new HelpContentNullException(command.GetDefaultId().GetText());

        if (command.GetAction() == null)
            throw new ActionNullException(ActionNullExceptionOptions.OnChecking, command.GetDefaultId().GetText());

        CommandPool.Pool?.Add(command);
    }
}