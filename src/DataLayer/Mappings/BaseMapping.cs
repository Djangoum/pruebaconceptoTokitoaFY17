using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Mappings
{
    public abstract class BaseMapping<TEntity> where TEntity : class
    {
        protected EntityTypeBuilder<TEntity> Entity { get; set; }
    
        public BaseMapping(ModelBuilder modelBuilder)
        {
            Entity = modelBuilder.Entity<TEntity>();
        }
    }
}
