using Refit;

namespace Arditi.JuheAPI.Region;

public interface IRegion
{
    [Get("/xzqh/query")]
    Task<MultipleResultResponse<RegionResult>> Get([AliasAs("fid")] string fId);
}
