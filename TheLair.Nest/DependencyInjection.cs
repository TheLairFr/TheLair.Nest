using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TheLair.Nest.Domain;
using TheLair.Nest.Infra;
using TheLair.Nest.ProjectSourcing;

namespace TheLair.Nest;

public class DependencyInjection
{
    public ServiceProvider ServiceProvider = null!;

    public void RegisterServices()
    {
        ServiceCollection services = new ServiceCollection();

        services.AddSingleton<ProjectManager>();
        services.AddSingleton<FileRepository<NestConfig>>(i => new FileRepository<NestConfig>("NestConfig.json"));
        services.AddSingleton<IProjectSource, GithubProjectSource>();

        ServiceProvider = services.BuildServiceProvider();
    }
}