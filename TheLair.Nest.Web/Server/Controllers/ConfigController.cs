using Microsoft.AspNetCore.Mvc;
using TheLair.Nest.Domain;
using TheLair.Nest.Infra;
using TheLair.Nest.Web.Shared;

namespace TheLair.Nest.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly FileRepository<NestConfig> ConfigRepository;

        public ConfigController(FileRepository<NestConfig> configRepo)
        {
            ConfigRepository = configRepo;
        }

        [HttpGet]
        public async Task<NestConfig> Get()
        {
            return (await ConfigRepository.Load());
        }
    }
}