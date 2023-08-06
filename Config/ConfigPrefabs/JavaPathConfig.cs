using MinecraftLaunch.Modules.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SLCore.Errors;

namespace SLCore.Config.ConfigPrefabs;

public class JavaPathConfig: IConfigSection
{
    public string ConfigId => "simplelauncher:javaPath";

    public string ConfigAliase => "javaPath";
    
    /// <summary>
    /// 此处应为FileInfo
    /// </summary>
    public object? ConfigContent { get; set; }
    
    public void ReadConfig(string path)
    {
        using (StreamReader reader = File.OpenText(path))
        {
            JObject obj = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

            if (!obj.ContainsKey(ConfigId))
                throw new WrongConfigSectionError($"指定了不存在的配置段: {ConfigId}");

            ConfigContent = new FileInfo(obj[ConfigId]?.Value<string>());
        }
    }

    public void WriteConfig(string path, string content)
    {
        using (StreamReader reader = File.OpenText(path))
        {
            JObject obj = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
            TextWriter textWriter = new StreamWriter(path);
            JsonWriter writer = new JsonTextWriter(textWriter);

            if (!obj.ContainsKey(ConfigId))
                throw new MultiConfigSectionError(this.ConfigId);
            
            obj[ConfigId] = content;
            
            obj.WriteTo(writer);
        } 
    }
}