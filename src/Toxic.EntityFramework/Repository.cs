using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Toxic.EntityFramework
{
    public sealed class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbSet<TEntity> Entities => _dbContext.Set<TEntity>();
        public EntityEntry<TEntity> Entry(TEntity entity)
        {
            return _dbContext.Entry(entity);
        }

        #region Query

        public IQueryable<TEntity> AsQueryable()
        {
            var queryable = Entities.AsQueryable();
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
            {
                queryable = queryable
                    .OrderByDescending(e => EF.Property<DateTime>(e, ShadowProperty.ModifiedOn))
                    .ThenByDescending(e => EF.Property<DateTime>(e, ShadowProperty.CreatedOn));
            }

            return queryable;
        }

        public IQueryable<TEntity> AsQueryableIgnoreQueryFilters()
        {
            return AsQueryable().IgnoreQueryFilters();
        }

        public IQueryable<TEntity> AsNoTracking()
        {
            var queryable = Entities.AsNoTracking();
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
            {
                queryable = queryable
                    .OrderByDescending(e => EF.Property<DateTime>(e, ShadowProperty.ModifiedOn))
                    .ThenByDescending(e => EF.Property<DateTime>(e, ShadowProperty.CreatedOn));
            }

            return queryable;
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

        public EntityEntry<TEntity> Add(TEntity entity)
        {
            return Entities.Add(entity);
        }

        public void AddRange(params TEntity[] entities)
        {
            Entities.AddRange(entities);
        }

        #endregion Add

        #region Modify

        public EntityEntry<TEntity> Modify(TEntity entity)
        {
            return Entities.Update(entity);
        }

        public void ModifyRange(params TEntity[] entities)
        {
            Entities.UpdateRange(entities);
        }

        #endregion Modify

        #region Remove

        public EntityEntry<TEntity> Remove(TEntity entity)
        {
            return Entities.Remove(entity);
        }

        public void RemoveRange(params TEntity[] entities)
        {
            Entities.RemoveRange(entities);
        }

        #endregion Remove
    }
}