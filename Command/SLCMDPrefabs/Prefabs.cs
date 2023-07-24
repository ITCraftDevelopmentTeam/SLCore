namespace SLCore.Command.SLCMDPrefabs;

public class Prefabs
{
    public static CommandInstance CMD_HELP = new CommandInstance(
        new string[3] { "help", "h", "hp" },
        "help: 查看SimpleLauncher的帮助\n" +
        "  |子命令: 所有已经注册的命令均为该命令的子命令\n" +
        "  |用法: help [sub command]\n" +
        "  |注意事项: 在输入该命令的子命令时，不需要输入对应命令的参数，直接输入该命令即可\n" +
        "  |  |\n" +
        "  |  | 举例: 'help find' 就是查找关于命令find的帮助，不需要填写find的参数\n" +
        "  -  -\n",
        null,
        new Action(args =>
            {
                if (args == null || args.Length == 0)
                {
                    string content = "SimpleLauncher帮助文档\n" +
                                     "本文档主要内容为启动器支持的所有命令的用法，以及一些其他的小技巧\n" +
                                     "\n" +
                                     "\n";
                    Console.Out.WriteLine(content);
                    foreach (var help in CommandPool.Pool)
                    {
                        Console.Out.WriteLine((help as CommandInstance)?.HelpContent);
                    }
                }
                else
                {
                    foreach (var help in CommandPool.Pool)
                    {
                        if ((help as CommandInstance).IsMatchId(args[0]))
                        {
                            Console.Out.WriteLine((help as CommandInstance).HelpContent);
                        }
                    }
                }
            },
            ActionType.Full
        )
    );

    public static CommandInstance CMD_EXIT = new CommandInstance(
        new string[3] { "exit", "quit", "q" },
        "exit | quit | q: 退出启动器\n",
        null,
        new Action(
            args =>
            {
                Console.Out.WriteLine("正在退出程序...");
                Environment.Exit(0);
            },
            ActionType.Full
        )
    );

    public static CommandInstance CMD_VERSION = new CommandInstance(
        new string[3] { "version", "ver", "Version" },
        "version | ver | Version: 查看启动器及其核心版本\n",
        null,
        new Action(
            args =>
            {
                Utils.SLOutput.Print("当前核心版本: " + CoreInfo.Info.CoreVersion, ConsoleColor.Green);
                Utils.SLOutput.Print("当前启动器版本: " + CoreInfo.Info.LauncherVersion, ConsoleColor.Green);
                Utils.SLOutput.Print("程序使用许可证: " + CoreInfo.Info.License, ConsoleColor.Cyan);
            },
            ActionType.Full
        )
    );
}