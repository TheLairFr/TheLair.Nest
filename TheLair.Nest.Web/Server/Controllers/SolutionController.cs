using Microsoft.AspNetCore.Mvc;
using TheLair.ASP_Net.Extensions;
using TheLair.ASP_Net.OneOfLogic;
using TheLair.Nest.Domain;
using TheLair.Nest.Infra;
using TheLair.Nest.Web.Shared.Mappers;
using TheLair.Nest.Web.Shared.Payloads;

namespace TheLair.Nest.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolutionController : ControllerBase
    {
        private readonly FileRepository<NestConfig> ConfigRepository;

        public SolutionController(FileRepository<NestConfig> configRepo)
        {
            ConfigRepository = configRepo;
        }

        [HttpPost]
        public async Task<OneOf<OkResult>> Post(CreateSolutionPayload payload)
        {
            NestConfig config = await ConfigRepository.Load();

            config.Solutions.Add(SolutionMapper.To(payload));

            await ConfigRepository.Save(config);
            return (Ok().OneOf());
        }

        [HttpDelete("{id}")]
        public async Task<OneOf<OkResult, NotFoundResult>> Delete(Guid id)
        {
            NestConfig config = await ConfigRepository.Load();
            Solution? solution = config.Solutions.FirstOrDefault(i => i.Id == id);

            if (solution == null)
                return (NotFound());

            config.Solutions.Remove(solution);

            await ConfigRepository.Save(config);
            return (Ok());
        }
    }
}