using SLCore.Commands;

namespace SLCore.Config;

/// <summary>
/// 配置文件的段
/// </summary>
public interface IConfigSection
{
    public string ConfigId { get; }
    public string ConfigAliase { get; }
    public object? ConfigContent { get; set; }

    public void ReadConfig(string path);
    public void WriteConfig(string path, string content);
}