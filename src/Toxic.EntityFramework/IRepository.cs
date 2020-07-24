using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Toxic.EntityFramework
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        #region Query

        IQueryable<TEntity> AsQueryable();

        IQueryable<TEntity> AsQueryableIgnoreQueryFilters();

        IQueryable<TEntity> AsNoTracking();

        IQueryable<TEntity> AsNoTrackingIgnoreQueryFilters();

        IQueryable<TEntity> FromSqlInterpolated(FormattableString sql);

        IQueryable<TEntity> FromSqlRaw(string sql, params object[] parameters);

        (int total, IQueryable<TEntity> data) Paging(IQueryable<TEntity> queryable, int size, int index = 1);

        Task<(int total, IQueryable<TEntity> data)> PagingAsync(IQueryable<TEntity> queryable, int size,
            int index = 1);

        #endregion Query

        #region Add

        /// <summary>
        /// 添加实体到上下文
        /// 实体状态标记为：Added
        /// </summary>
        EntityEntry<TEntity> Add(TEntity entity);

        /// <summary>
        /// 添加实体到上下文
        /// 实体状态标记为：Added
        /// </summary>
        void AddRange(params TEntity[] entities);

        #endregion Add

        #region Modify

        /// <summary>
        /// 更新实体到上下文
        /// 实体状态标记为：Modified
        /// </summary>
        EntityEntry<TEntity> Modify(TEntity entity);

        /// <summary>
        /// 更新实体到上下文
        /// 实体状态标记为：Modified
        /// </summary>
        void ModifyRange(params TEntity[] entities);

        #endregion Modify

        #region Remove

        /// <summary>
        /// 删除实体到上下文
        /// 实体状态标记为：Deleted
        /// 如果实体实现软删除接口则将实体状态标记为：Modified
        /// </summary>
        EntityEntry<TEntity> Remove(TEntity entity);

        /// <summary>
        /// 删除实体到上下文
        /// 实体状态标记为：Deleted
        /// 如果实体实现软删除接口则将实体状态标记为：Modified
        /// </summary>
        void RemoveRange(params TEntity[] entities);

        #endregion Remove
    }
}