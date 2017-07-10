using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Linq;
using System.Reflection;
using XCutting.ModelBuilderExtensions;

namespace XCutting.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void GetConfigurationsFromAssembly<TContext>(this ModelBuilder modelBuilder) where TContext : DbContext
        {
            var Assembly = typeof(TContext).GetTypeInfo().Assembly;
            foreach(var type in Assembly.GetTypes())
            {
                if(type.GetInterfaces().Any(x =>
                      x.IsConstructedGenericType &&
                      x.GetGenericTypeDefinition() == typeof(IEntityConfiguration<>)) && (!type.GetTypeInfo().IsInterface))
                {
                    type.GetMethod("Configure").Invoke(Activator.CreateInstance(type, modelBuilder), null);
                }
            }
        }

        public static void DisableCascadeDeleteConvention(this ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
