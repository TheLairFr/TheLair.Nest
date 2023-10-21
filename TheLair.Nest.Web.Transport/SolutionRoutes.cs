using TheLair.HTTP;
using TheLair.HTTP.Json;
using TheLair.Nest.Domain;
using TheLair.Nest.Web.Shared.Payloads;

namespace TheLair.Nest.Web.Transport;

public partial class NestHttpClient : JsonHttpClient
{
    public Task<Response> CreateSolution(CreateSolutionPayload payload)
    {
        return (Post("api/solution", payload));
    }

    public Task DeleteSolution(Solution solution)
    {
        return (Delete($"api/solution/{solution.Id}"));
    }
}