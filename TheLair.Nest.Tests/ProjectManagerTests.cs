using Microsoft.Extensions.DependencyInjection;
using TheLair.Nest.Domain;

namespace TheLair.Nest.Tests
{
    [TestClass]
    public class ProjectManagerTests
    {
        [TestMethod]
        public void CloneAndBuild()
        {
            DependencyInjection di = new DependencyInjection();

            di.RegisterServices();

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
        }
    }
}