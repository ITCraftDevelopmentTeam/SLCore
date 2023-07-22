using SLCore.Errors;

namespace SLCore.Command;

public class CommandHandler
{
    public static bool HandCommand(string input)
    {
        if (CommandPool.Pool == null)
            throw new CommandPoolNullException();

        string[] segs = input.Split(' ');
        
        foreach (CommandInstance cmd in CommandPool.Pool)
        {
            if (cmd.IsMatchId(segs[0]))
            {
                return cmd.Do(segs.Skip(1).ToArray());
            }
        }

        return false;
    }
}