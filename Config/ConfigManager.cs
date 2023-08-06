using SLCore.Config.ConfigPrefabs;
using SLCore.Errors;

namespace SLCore.Config;

public class ConfigManager
{
    private List<IConfigSection> _configs;

    public ConfigManager()
    {
        if (!Directory.Exists(@"./sl_settings"))
            Directory.CreateDirectory(@"./sl_settings");
        if (!File.Exists(@"./sl_settings/config.json"))
            File.Create(@"./sl_settings/config.json");
        
        _configs = new List<IConfigSection>();

        var javaPathConfig = new JavaPathConfig();
        _configs.Add(javaPathConfig);
    }

    public void Register(IConfigSection config)
    {
        if (_configs.Contains(config))
            throw new MultiConfigSectionError(config.ConfigId);
        
        _configs?.Add(config);
    }

    public IConfigSection GetConfig(string idOrAliase)
    {
        foreach (var config in _configs)
        {
            if (config.ConfigAliase == idOrAliase || config.ConfigId == idOrAliase)
                return config;
        }

        throw new WrongConfigSectionError($"指定了错误的配置段: {idOrAliase}; 这个问题也可能是您的拼写错误导致的，请您检查您的拼写");
    }
}