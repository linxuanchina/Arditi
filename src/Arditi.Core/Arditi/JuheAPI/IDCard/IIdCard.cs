using Refit;

namespace Arditi.JuheAPI.IDCard;

public interface IIdCard
{
    [Get("/idcard/index")]
    Task<SingleResultResponse<IdCardResult>> Get([AliasAs("cardno")] string cardNo);
}
