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
        new Action(subs =>
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

                return true;
            },
            ActionType.Full
        )
    );
}