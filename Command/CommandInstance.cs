namespace SLCore.Command;

using System;
using System.Collections;
using SLCore.Errors;

public delegate bool HandCmdAction(string[] subs);

/// <summary>
/// 决定Action的类型，默认为Seg
/// </summary>
public enum ActionType
{
    /// <summary>
    /// 将继续调用子命令
    /// </summary>
    Seg,

    /// <summary>
    /// 不调用子命令，剩下的均归该Action所有
    /// </summary>
    Full
}

public class Action
{
    private ActionType? _actionType;
    private HandCmdAction? _actionBody = null;

    public Action(HandCmdAction? action, ActionType actionType)
    {
        _actionBody = action;
        _actionType = actionType;
    }

    public Action(ActionType actionType)
    {
        _actionBody = null;
        _actionType = actionType;
    }

    public new ActionType? GetType()
    {
        if (_actionType == null)
            throw new ActionNullException(ActionNullExceptionOptions.OnUsing);
        else return _actionType;
    }

    public bool Do(string[]? args)
    {
        if (_actionBody == null)
            throw new ActionNullException(ActionNullExceptionOptions.OnUsing);
        else return _actionBody(args);
    }

    public void BindBody(HandCmdAction action)
    {
        if (_actionType == ActionType.Seg)
            throw new BindActionException(BindActionExceptionOptions.UnMatchedType);
        
        _actionBody = action;
    }
}

public class Identifier
{
    private string? _text;

    public Identifier(string? text) => this._text = text;

    public string? GetText() => this._text;

    public bool RewriteIdentifier(string? text)
    {
        this._text = text;
        return this._text != null;
    }
}

public class CommandInstance
{
    private Identifier?[] _id = new Identifier[3];
    private Action? _action;
    public CommandInstance?[]? Subs = null;
    /// <summary>
    /// 指令的帮助
    /// </summary>
    public string? HelpContent;

    public CommandInstance(string[] ids, string help, CommandInstance[]? sub_cmds, HandCmdAction action)
    {
        int index = 0;
        foreach (string id in ids)
        {
            this._id[index] = new Identifier(id);
            ++index;
        }

        this.HelpContent = help;
        
        this.Subs = sub_cmds;

        this._action = new Action(action, ActionType.Seg);
    }

    public CommandInstance(string[] ids, CommandInstance[]? sub_cmds)
    {
        int index = 0;
        foreach (string id in ids)
        {
            this._id[index] = new Identifier(id);
            ++index;
        }

        this.Subs = sub_cmds;
    }

    public CommandInstance(string text, HandCmdAction action)
    {
        this._id[0] = new Identifier(text);
        this._action = new Action(action, ActionType.Seg);
    }

    public CommandInstance(Identifier id, HandCmdAction action)
    {
        this._id[0] = id;
        this._action = new Action(action, ActionType.Seg);
    }

    public CommandInstance(string[] ids, HandCmdAction action)
    {
        int index = 0;
        foreach (string id in ids)
        {
            this._id[index] = new Identifier(id);
            ++index;
        }

        this._action = new Action(action, ActionType.Seg);
    }

    public CommandInstance(string[] ids, string help, CommandInstance[]? sub_cmds, Action action)
    {
        int index = 0;
        foreach (string id in ids)
        {
            this._id[index] = new Identifier(id);
            ++index;
        }

        this.HelpContent = help;
        
        this.Subs = sub_cmds;

        this._action = action;
    }

    public CommandInstance(string text, Action action)
    {
        this._id[0] = new Identifier(text);
        this._action = action;
    }

    public CommandInstance(Identifier id, Action action)
    {
        this._id[0] = id;
        this._action = action;
    }

    public CommandInstance(string[] ids, Action action)
    {
        int index = 0;
        foreach (string id in ids)
        {
            this._id[index] = new Identifier(id);
            ++index;
        }

        this._action = action;
    }

    public CommandInstance(string text) => this._id[0] = new Identifier(text);

    public CommandInstance(Identifier id) => this._id[0] = id;

    public CommandInstance(string[] ids)
    {
        int index = 0;
        foreach (string id in ids)
        {
            this._id[index] = new Identifier(id);
            ++index;
        }
    }

    //举个例子
    // 现在的命令： forge install 1.0.0
    public bool Do(string[]? subs)
    {
        if (_action?.GetType() == ActionType.Seg)
        {
            // 处理 “install 1.0.0” (当然install这里为Full-Action，应该在下面的块中)
            foreach (var child in Subs)
            {
                if (child == null) continue;

                if (child.IsMatchId(subs[0]))
                {
                    return child.Do(ArgumentManager.ConsumeHead(subs));
                }
            }

            throw new CommandArgumentError(CommandArgumentErrorOptions.WrongParameterError);
        }
        else
        {
            // 如果是Full类型的Action则剩下的全交给该Action
            return _action.Do(ArgumentManager.ConsumeHead(subs));
        }
    }

    public Action? GetAction() => _action;

    public void Bind(HandCmdAction method) => _action?.BindBody(method);

    public Identifier? GetId(int index) => _id[index];
    
    public Identifier? GetDefaultId() => _id[0];

    public Identifier?[] GetIds() => _id;

    public bool IsMatchId(string? text)
    {
        foreach (Identifier? identifier in _id)
        {
            if (identifier?.GetText() == text)
                return true;
        }

        return false;
    }
}