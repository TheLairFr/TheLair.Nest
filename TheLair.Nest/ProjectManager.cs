using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliWrap;
using TheLair.Nest.Domain;
using TheLair.Nest.Infra;
using TheLair.Nest.ProjectSourcing;

namespace TheLair.Nest;

public class ProjectManager
{
    private readonly FileRepository<NestConfig> ConfigRepository;
    private readonly IProjectSource ProjectSource;

    public ProjectManager(FileRepository<NestConfig> configRepository, IProjectSource projectSource)
    {
        ConfigRepository = configRepository;
        ProjectSource = projectSource;
    }

    public async Task SetupProject(Solution solution)
    {
        NestConfig config = await ConfigRepository.Load();

        config.Solutions.Add(solution);

        solution.LocalProjectPath = $"{Guid.NewGuid()}/";

        await ProjectSource.GetSources(solution);

        foreach (Project project in solution.Projects)
        {
            bool fail = false;
            Output.DisplayInfo($"Building project {project.Name}");

            foreach (CommandStep step in project.BuildCommands)
            {
                var r = await Cli.Wrap(step.GetBin())
                    .WithArguments(step.GetArgs())
                    .WithWorkingDirectory(Path.Join(solution.LocalProjectPath, step.Path))
                    .WithStandardOutputPipe(PipeTarget.ToDelegate(Output.DisplayInfo))
                    .WithStandardErrorPipe(PipeTarget.ToDelegate(Output.DisplayInfo))
                    .ExecuteAsync();

                if (r.ExitCode != 0)
                {
                    fail = true;
                    Output.DisplayError($"Return Code {r.ExitCode}");
                    break;
                }
            }

            if (fail)
                Output.DisplayError($"Project {project.Name} could not be built");
            else
                Output.DisplayInfo($"Project {project.Name} was built !");
        }

        await ConfigRepository.Save(config);
    }
}