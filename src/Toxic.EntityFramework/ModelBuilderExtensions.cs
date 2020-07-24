using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Toxic.EntityFramework
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// 使用软删除查询过滤器
        /// </summary>
        public static ModelBuilder HasSoftDeleteQueryFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                .Where(entityType => typeof(ISoftDeleteEntity).IsAssignableFrom(entityType.ClrType))
                .ToList().ForEach(entityType =>
                {
                    modelBuilder.Entity(entityType.ClrType).Property<bool>("IsDeleted");
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var body = Expression.Equal(
                        Expression.Call(typeof(EF),
                            nameof(EF.Property),
                            new[] { typeof(bool) },
                            parameter, Expression.Constant("IsDeleted")),
                        Expression.Constant(false));
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
                });
            return modelBuilder;
        }
    }
}