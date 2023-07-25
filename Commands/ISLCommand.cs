using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLCore.Commands;
public interface ISLCommand
{
    string Id { get; }
    IEnumerable<string> Aliases { get; }
    string HelpContent { get; }
    Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args);
}
