using SLCore.Errors;

namespace SLCore.Command;

public class CommandHandler
{
    public static void HandCommand(string input)
    {
        bool isDone = false;
        
        if (CommandPool.Pool == null)
            throw new CommandPoolNullException();

        string[] segs = input.Split(' ');
        
        foreach (SLCommand cmd in CommandPool.Pool)
        {
            if (cmd.IsMatchId(segs[0]))
            {
                cmd.Do(segs.Skip(1).ToArray());
                isDone = true;
            }
        }

        if (!isDone)
            throw new UnknownCommandError(input);
    }
    
    public static void HandCommand(string[] args)
    {
        bool isDone = false;
        
        if (CommandPool.Pool == null)
            throw new CommandPoolNullException();

        foreach (SLCommand cmd in CommandPool.Pool)
        {
            if (cmd.IsMatchId(args[0]))
            {
                cmd.Do(args.Skip(1).ToArray());
                isDone = true;
            }
        }

        if (!isDone)
            throw new UnknownCommandError(ArgumentManager.MergeArgs(args));
    }
}