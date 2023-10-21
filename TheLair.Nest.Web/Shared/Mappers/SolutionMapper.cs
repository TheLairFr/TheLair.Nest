using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLair.Nest.Domain;
using TheLair.Nest.Web.Shared.Payloads;

namespace TheLair.Nest.Web.Shared.Mappers;

public class SolutionMapper :
    MyMapperTo<CreateSolutionPayload, Solution>
{
    public static Solution To(CreateSolutionPayload source)
    {
        return (new Solution
        {
            Id = source.Id,
            Name = source.Name,
            GithubURL = source.GithubURL,
        });
    }
}