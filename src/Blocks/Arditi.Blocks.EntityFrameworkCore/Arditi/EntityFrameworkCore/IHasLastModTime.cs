namespace Arditi.EntityFrameworkCore;

public interface IHasLastModTime
{
    DateTime? LastModTime { get; set; }
}
