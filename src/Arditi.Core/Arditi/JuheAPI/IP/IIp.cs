using Refit;

namespace Arditi.JuheAPI.IP;

public interface IIp
{
    [Get("/ip/ipNewV3")]
    Task<SingleResultResponse<IpResult>> Get([AliasAs("ip")] string ip);
}
