using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dawn;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Toxic.EntityFramework
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddUnitOfWork<TDbContext>(
            this IServiceCollection services)
            where TDbContext : DbContext
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork<TDbContext>>();
        }

        public static IServiceCollection AddUnitOfWorkAndRepositories<TDbContext>(
            this IServiceCollection services)
            where TDbContext : DbContext
        {
            AddUnitOfWork<TDbContext>(services);
            AddRepositories<TDbContext>(services, typeof(TDbContext).GetTypeInfo().Assembly);
            return services;
        }

        public static IServiceCollection AddRepositories<TDbContext>(this IServiceCollection services,
            params Assembly[] assemblies)
            where TDbContext : DbContext
        {
            assemblies = Guard.Argument(assemblies, nameof(assemblies)).NotNull().NotEmpty();
            var definedTypes = new List<TypeInfo>();
            foreach (var assembly in assemblies)
            {
                definedTypes.AddRange(assembly.DefinedTypes);
            }

            foreach (var entityType in definedTypes
                .Select(typeInfo => typeInfo.AsType())
                .Where(type => type.IsClass && typeof(IEntity).IsAssignableFrom(type)))
            {
                services.AddTransient(typeof(IRepository<>).MakeGenericType(entityType), serviceProvider =>
                    typeof(Repository<>)
                        .MakeGenericType(entityType)
                        .GetConstructor(new[] {typeof(DbContext)})
                        ?.Invoke(new object[]
                            {serviceProvider.GetRequiredService<TDbContext>()}));
            }

            return services;
        }
    }
}