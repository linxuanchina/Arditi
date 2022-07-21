namespace Arditi.EntityFrameworkCore;

public interface IHasModificationTime
{
    DateTime? LastModificationTime { get; set; }
}
