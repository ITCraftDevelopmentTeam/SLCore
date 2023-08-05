using SLCore.Commands;

namespace SLCore.Config;

public interface IConfigSection
{
    public string ConfigID { get; }
    public IEnumerable<string> ConfigAliases { get; }
    public object ConfigContent { get; set; }

    public void ReadConfig(string path);
    public void WriteConfig(string path);
}