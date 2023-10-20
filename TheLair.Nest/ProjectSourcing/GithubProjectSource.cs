using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;
using TheLair.Nest.Domain;
using TheLair.Nest.Infra;

namespace TheLair.Nest.ProjectSourcing;

public class GithubProjectSource : IProjectSource
{
    public async Task GetSources(Solution project)
    {
        var result = await Cli.Wrap("git")
            .WithArguments(new string[] { "clone", project.GithubURL, project.LocalProjectPath})
            .WithStandardOutputPipe(PipeTarget.ToDelegate(Output.DisplayInfo))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(Output.DisplayInfo))
            .ExecuteAsync();

        Output.DisplayInfo($"Status code {result.ExitCode}");
    }
}