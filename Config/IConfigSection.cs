using System.Text.Json.Serialization;
using SLCore.Commands;

namespace SLCore.Config;

/// <summary>
/// 配置文件的段
/// </summary>
public interface IConfigSection
{
    [Newtonsoft.Json.JsonIgnore]
    public string ConfigId { get; }
    [Newtonsoft.Json.JsonIgnore]
    public string ConfigAliase { get; }
}