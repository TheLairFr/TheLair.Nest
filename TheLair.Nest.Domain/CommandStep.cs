using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLair.Nest.Domain;

public class CommandStep
{
    public string Path { get; set; } = String.Empty;
    public string Command { get; set; } = String.Empty;

    public CommandStep() { }
    public CommandStep(string path, string command)
    {
        Path = path;
        Command = command;
    }

    public string GetBin()
    {
        return (Command.Substring(0, Command.IndexOf(' ')));
    }

    public string GetArgs()
    {
        int idx = Command.IndexOf(' ');

        return (Command.Substring(idx, Command.Length - idx - 1));
    }
}