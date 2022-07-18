namespace Arditi.EntityFrameworkCore;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
    DateTime? DeletionTime { get; set; }
}
