using System.Collections.ObjectModel;
using SLCore.Commands.Prefabs;

namespace SLCore.Commands;

public sealed class CommandPool
{
    private readonly List<ISLCommand> commands;
    public IReadOnlyList<ISLCommand> Commands { get; }

    public CommandPool(SimpleLauncherCore core)
    {
        this.commands = new List<ISLCommand>();
        this.Commands = new ReadOnlyCollection<ISLCommand>(commands);
    }

    public void Register(ISLCommand command)
    {
        this.commands.Add(command);
    }

    public void Remove(ISLCommand command)
    {
        _ = this.commands.Remove(command);
    }

    private static async ValueTask ExecuteRecursivelyAsync(ISLCommand? command, IEnumerable<string> args)
    {
        for (; command is not null;)
        {
            command = await command.ExecuteAsync(args);
            args = args.Skip(1);
        }
    }

    public ISLCommand? FindExactlyMatched(string commandIdOrAlias)
    {
        ISLCommand? result = null;
        foreach (var command in this.commands)
        {
            if (command.Id == commandIdOrAlias)
                return command;

            if (command.Aliases.Contains(commandIdOrAlias))
            {
                result = command;
                continue;
            }
        }
        return result;
    }

    public async ValueTask ExecuteAsync(string commandText)
    {
        string[] args = commandText.Split(
            new char[] { ' ', '\t' },
            StringSplitOptions.RemoveEmptyEntries);
        if (args.Length is 0)
            return;

        var command = this.FindExactlyMatched(args[0]);
        await ExecuteRecursivelyAsync(command, args.Skip(1));
    }
}
