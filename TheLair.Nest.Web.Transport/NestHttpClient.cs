using TheLair.HTTP.Json;

namespace TheLair.Nest.Web.Transport;

public partial class NestHttpClient : JsonHttpClient
{
    public NestHttpClient(HttpClient client) : base(client) { }
}