namespace SLCore.Config.ConfigPrefabs;

public class JavaPathConfig: IConfigSection
{
    public string ConfigID => "simplelauncher:javaPath";

    public IEnumerable<string> ConfigAliases => new string[]
    {
        "java_path", "javaPath", "JavaPath", "jap"
    };
    
    public object ConfigContent { get; set; }
    
    public void ReadConfig(string path)
    {
        throw new NotImplementedException();
    }

    public void WriteConfig(string path)
    {
        throw new NotImplementedException();
    }
}