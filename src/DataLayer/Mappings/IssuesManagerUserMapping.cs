using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCutting.ModelBuilderExtensions;
using Microsoft.EntityFrameworkCore;
using IssuesManager.Models;

namespace DataLayer.Mappings
{
    public class IssuesManagerUserMapping : BaseMapping<IssuesManagerUser>, IEntityConfiguration<IdentityContext>
    {
        public IssuesManagerUserMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure()
        {
            Entity.HasMany(x => x.ManagedProjects).WithOne(x => x.Manager).HasForeignKey(x => x.ManagerId);
            Entity.HasMany(x => x.CreatedUserStories).WithOne(x => x.Creator).HasForeignKey(x => x.CreatedBy);
            Entity.HasMany(x => x.AssignedToUserStories).WithOne(x => x.Assigned).HasForeignKey(x => x.AssignedTo);
            Entity.HasMany(x => x.CreatedTasks).WithOne(x => x.Creator).HasForeignKey(x => x.CreatedBy);
            Entity.HasMany(x => x.AssignedToTasks).WithOne(x => x.Assigned).HasForeignKey(x => x.AssignedTo);
        }
    }
}
