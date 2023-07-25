using System.Collections.ObjectModel;
using SLCore.Commands.Prefabs;
using SLCore.Errors;

namespace SLCore.Commands;

public sealed class CommandPool : IDisposable
{
    private readonly List<ISLCommand> commands;
    public IReadOnlyList<ISLCommand> Commands { get; }

    public CommandPool(SimpleLauncherCore core)
    {
        this.commands = new List<ISLCommand>();
        this.Commands = new ReadOnlyCollection<ISLCommand>(commands);

        this.Register(new HelpCommand(core));
        this.Register(new VersionCommand(core));
        this.Register(new ExitCommand());
    }

    public void Register(ISLCommand command)
    {
        this.commands.Add(command);
    }

    public void Remove(ISLCommand command)
    {
        _ = this.commands.Remove(command);
    }

    private static async ValueTask ExecuteRecursively(ISLCommand? command, IEnumerable<string> args)
    {
        for (; command is not null;)
        {
            command = await command.Execute(args);
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

    public async Task Execute(string commandText)
    {
        string[] args = commandText.Split(
            new char[] { ' ', '\t' },
            StringSplitOptions.RemoveEmptyEntries);
        if (args.Length is 0)
            return;

        var command = this.FindExactlyMatched(args[0]);
        await ExecuteRecursively(command, args.Skip(1));
    }

    public void Dispose()
    {
        foreach (var command in this.commands)
            command.Dispose();
    }
}
