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
            foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes()
                .Where(entityType => typeof(ISoftDeleteEntity).IsAssignableFrom(entityType.ClrType)))
            {
                var parameter = Expression.Parameter(mutableEntityType.ClrType, "entity");
                var body = Expression.Equal(
                    Expression.Call(typeof(EF),
                        nameof(EF.Property),
                        new[] {typeof(bool)},
                        parameter, Expression.Constant(ShadowProperty.IsDeleted)),
                    Expression.Constant(false));
                modelBuilder.Entity(mutableEntityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
            }

            return modelBuilder;
        }
    }
}