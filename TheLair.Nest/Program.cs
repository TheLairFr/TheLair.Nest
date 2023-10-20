using Microsoft.Extensions.DependencyInjection;
using TheLair.Nest;
using TheLair.Nest.Domain;
using TheLair.Nest.Infra;

DependencyInjection di = new DependencyInjection();

di.RegisterServices();

Output.DisplayInfo("Services are setting up");

di.ServiceProvider.GetRequiredService<ProjectManager>().SetupProject(new Solution
{
    GithubURL = "https://github.com/nvareille/NWS-TDDStackExample",
    Projects = new List<Project>
    {
        new Project
        {
            Name = "TDDServer",
            BuildCommands = new CommandStep[]
            {
                new CommandStep("TDDStackExample/Server", "dotnet publish -c Release")
            }
        }
    }
}).Wait();

Console.ReadLine();