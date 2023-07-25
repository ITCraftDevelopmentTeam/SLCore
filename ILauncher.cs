using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLCore;
public interface ILauncher
{
    public string LauncherVersion { get; }

    public void RequestClose();
}
