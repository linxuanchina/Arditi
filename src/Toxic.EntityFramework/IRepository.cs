using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Toxic.EntityFramework
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        DbSet<TEntity> Entities { get; }
        EntityEntry<TEntity> Entry(TEntity entity);
        
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
        
        EntityEntry<TEntity> Add(TEntity entity);
        
        void AddRange(params TEntity[] entities);

        #endregion Add

        #region Modify
        
        EntityEntry<TEntity> Modify(TEntity entity);
        void ModifyRange(params TEntity[] entities);

        #endregion Modify

        #region Remove
        
        EntityEntry<TEntity> Remove(TEntity entity);
        void RemoveRange(params TEntity[] entities);

        #endregion Remove
    }
}