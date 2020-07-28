using System;
using System.Linq;
using System.Threading.Tasks;
using Dawn;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Toxic.EntityFramework
{
    public sealed class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        private DbSet<TEntity> Entities => _dbContext.Set<TEntity>();
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Query

        public IQueryable<TEntity> AsQueryable()
        {
            return Entities.AsQueryable();
        }

        public IQueryable<TEntity> AsQueryableIgnoreQueryFilters()
        {
            return AsQueryable().IgnoreQueryFilters();
        }

        public IQueryable<TEntity> AsNoTracking()
        {
            return Entities.AsNoTracking();
        }

        public IQueryable<TEntity> AsNoTrackingIgnoreQueryFilters()
        {
            return AsNoTracking().IgnoreQueryFilters();
        }

        public IQueryable<TEntity> FromSqlInterpolated(FormattableString sql)
        {
            return Entities.FromSqlInterpolated(sql);
        }

        public IQueryable<TEntity> FromSqlRaw(string sql, params object[] parameters)
        {
            return Entities.FromSqlRaw(sql, parameters);
        }

        public (int total, IQueryable<TEntity> data) Paging(IQueryable<TEntity> queryable, int size, int index = 1)
        {
            if (index < 1) index = 1;
            return (queryable.Count(), queryable.Skip(size * (index - 1)).Take(size));
        }

        public async Task<(int total, IQueryable<TEntity> data)> PagingAsync(IQueryable<TEntity> queryable, int size,
            int index = 1)
        {
            if (index < 1) index = 1;
            return (await queryable.CountAsync(), queryable.Skip(size * (index - 1)).Take(size));
        }

        #endregion Query

        #region Add

        private void SetEntityDefinedValueForAdd(params TEntity[] entities)
        {
            entities = Guard.Argument(entities, nameof(entities)).NotNull().NotEmpty();
            var entityType = typeof(TEntity);
            foreach (var entity in entities)
            {
                if (typeof(IAuditEntity).IsAssignableFrom(entityType))
                {
                    entityType.GetProperty(nameof(IAuditEntity.CreatedOn))?.SetValue(entity, DateTime.Now);
                    entityType.GetProperty(nameof(IAuditEntity.ModifiedOn))?.SetValue(entity, null);
                }

                if (typeof(ISoftDeleteEntity).IsAssignableFrom(entityType))
                {
                    entityType.GetProperty(nameof(ISoftDeleteEntity.IsDeleted))?.SetValue(entity, false);
                    entityType.GetProperty(nameof(ISoftDeleteEntity.DeletedOn))?.SetValue(entity, null);
                }
            }
        }

        /// <summary>
        /// 添加实体到上下文
        /// 实体状态标记为：Added
        /// </summary>
        public EntityEntry<TEntity> Add(TEntity entity)
        {
            SetEntityDefinedValueForAdd(entity);
            return Entities.Add(entity);
        }

        /// <summary>
        /// 添加实体到上下文
        /// 实体状态标记为：Added
        /// </summary>
        public void AddRange(params TEntity[] entities)
        {
            SetEntityDefinedValueForAdd(entities);
            Entities.AddRange(entities);
        }

        #endregion Add

        #region Modify

        private void SetEntityDefinedValueForModify(params TEntity[] entities)
        {
            entities = Guard.Argument(entities, nameof(entities)).NotNull().NotEmpty();
            var entityType = typeof(TEntity);
            if (typeof(IAuditEntity).IsAssignableFrom(entityType))
            {
                foreach (var entity in entities)
                {
                    entityType.GetProperty(nameof(IAuditEntity.ModifiedOn))?.SetValue(entity, DateTime.Now);
                }
            }
        }

        /// <summary>
        /// 更新实体到上下文
        /// 实体状态标记为：Modified
        /// </summary>
        public EntityEntry<TEntity> Modify(TEntity entity)
        {
            SetEntityDefinedValueForModify(entity);
            return Entities.Update(entity);
        }

        /// <summary>
        /// 更新实体到上下文
        /// 实体状态标记为：Modified
        /// </summary>
        public void ModifyRange(params TEntity[] entities)
        {
            SetEntityDefinedValueForModify(entities);
            Entities.UpdateRange(entities);
        }

        #endregion Modify

        #region Remove

        private void SetEntityDefinedValueForRemove(out bool isSoftDelete, params TEntity[] entities)
        {
            entities = Guard.Argument(entities, nameof(entities)).NotNull().NotEmpty();
            var entityType = typeof(TEntity);
            isSoftDelete = typeof(ISoftDeleteEntity).IsAssignableFrom(entityType);
            if (isSoftDelete)
            {
                foreach (var entity in entities)
                {
                    entityType.GetProperty(nameof(ISoftDeleteEntity.IsDeleted))?.SetValue(entity, true);
                    entityType.GetProperty(nameof(ISoftDeleteEntity.DeletedOn))?.SetValue(entity, DateTime.Now);
                }
            }
        }

        /// <summary>
        /// 删除实体到上下文
        /// 实体状态标记为：Deleted
        /// 如果实体实现软删除接口则将实体状态标记为：Modified
        /// </summary>
        public EntityEntry<TEntity> Remove(TEntity entity)
        {
            SetEntityDefinedValueForRemove(out var isSoftDelete, entity);
            return isSoftDelete ? Entities.Update(entity) : Entities.Remove(entity);
        }

        /// <summary>
        /// 删除实体到上下文
        /// 实体状态标记为：Deleted
        /// 如果实体实现软删除接口则将实体状态标记为：Modified
        /// </summary>
        public void RemoveRange(params TEntity[] entities)
        {
            SetEntityDefinedValueForRemove(out var isSoftDelete, entities);
            if (isSoftDelete)
            {
                Entities.UpdateRange(entities);
            }
            else
            {
                Entities.RemoveRange(entities);
            }
        }

        #endregion Remove
    }
}