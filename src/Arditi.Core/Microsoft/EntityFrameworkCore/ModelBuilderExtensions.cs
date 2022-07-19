using Arditi.EntityFrameworkCore;

namespace Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtensions
{
    public static void HasSoftDeleteQueryFilter(this ModelBuilder builder) =>
        builder.Entity<ISoftDelete>().HasQueryFilter(entity => !entity.IsDeleted);
}
