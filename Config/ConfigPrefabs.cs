using MinecraftLaunch.Modules.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SLCore.Errors;

namespace SLCore.Config.ConfigPrefabs;

public class JavaPathConfig: IConfigSection
{
    public string ConfigId => "simplelauncher:config:javaPath";
    public string ConfigAliase => "javaPath";
    public string javaPath => "null";
}