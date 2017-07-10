using Entities.IssuesManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCutting.ModelBuilderExtensions;
using Microsoft.EntityFrameworkCore;
using DataLayer.Context;

namespace DataLayer.Mappings
{
    public class UserStoryContainerMapping : BaseMapping<UserStoryContainer>, IEntityConfiguration<IssuesManagerContext>
    {
        public UserStoryContainerMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure()
        {
            Entity.HasKey(x => x.Id);
            Entity.HasOne(x => x.Project).WithMany(x => x.UserStoryContainers).HasForeignKey(x => x.ProjectId);
            Entity.HasMany(x => x.UserStories).WithOne(x => x.Container).HasForeignKey(X => X.ContainerId);
        }
    }
}
