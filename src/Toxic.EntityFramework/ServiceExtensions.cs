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
        public static IServiceCollection AddUnitOfWork<TContext>(
            this IServiceCollection services)
            where TContext : DbContext
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services, params Assembly[] assemblies)
        {
            assemblies = Guard.Argument(assemblies, nameof(assemblies)).NotNull().NotEmpty();
            var definedTypes = new List<TypeInfo>();
            foreach (var assembly in assemblies)
            {
                definedTypes.AddRange(assembly.DefinedTypes);
            }
            foreach (var interfaceTypeInfo in definedTypes.Where(typeInfo => typeInfo.IsInterface))
            {
                var repositoryType = interfaceTypeInfo.ImplementedInterfaces.SingleOrDefault(type =>
                    type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IRepository<>));
                if (repositoryType.IsNotNull())
                {
                    var repositoryImplType = definedTypes.SingleOrDefault(type => type.IsClass && repositoryType.IsAssignableFrom(type));
                    if (repositoryImplType.IsNull())
                    {
                        services.AddTransient(repositoryType, typeof(Repository<>).MakeGenericType(repositoryType.GetGenericArguments().First()));
                    }
                    else
                    {
                        services.AddTransient(repositoryType, repositoryImplType);
                    }
                }
            }
            return services;
        }
    }
}