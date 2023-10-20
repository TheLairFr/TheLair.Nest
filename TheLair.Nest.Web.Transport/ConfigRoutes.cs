using TheLair.HTTP;
using TheLair.HTTP.Json;
using TheLair.Nest.Domain;

namespace TheLair.Nest.Web.Transport;

public partial class NestHttpClient : JsonHttpClient
{
    public Task<Response<NestConfig>> GetConfig()
    {
        return (Get<NestConfig>("api/config/"));
    }
}