using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLair.Nest.Domain;

namespace TheLair.Nest.ProjectSourcing;

public interface IProjectSource
{
    Task GetSources(Solution project);
}