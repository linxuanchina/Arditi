namespace Arditi.EntityFrameworkCore;

public interface ICreationAudited : IHasCreationTime
{
    int? CreatorUserId { get; set; }
}
