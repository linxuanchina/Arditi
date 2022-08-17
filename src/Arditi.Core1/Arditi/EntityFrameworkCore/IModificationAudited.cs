namespace Arditi.EntityFrameworkCore;

public interface IModificationAudited : IHasModificationTime
{
    int? LastModifierUserId { get; set; }
}
