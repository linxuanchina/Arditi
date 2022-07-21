namespace Arditi.EntityFrameworkCore;

public interface IDeletionAudited : ISoftDelete
{
    int? DeleterUserId { get; set; }
}
