using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLair.Nest.Domain;

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = String.Empty;
    public CommandStep[] BuildCommands = Array.Empty<CommandStep>();
}