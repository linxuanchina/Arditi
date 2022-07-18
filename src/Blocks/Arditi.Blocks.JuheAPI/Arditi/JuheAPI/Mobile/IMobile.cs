using Refit;

namespace Arditi.JuheAPI.Mobile;

public interface IMobile
{
    [Get("/mobile/get")]
    Task<SingleResultResponse<MobileResult>> Get([AliasAs("phone")] string phone);
}
