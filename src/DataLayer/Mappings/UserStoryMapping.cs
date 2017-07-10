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
    public class UserStoryMapping : BaseMapping<UserStory>, IEntityConfiguration<IssuesManagerContext>
    {
        public UserStoryMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure()
        {
            Entity.Property(x => x.Title).IsRequired().HasMaxLength(300);
            Entity.Property(x => x.Description).IsRequired();
            Entity.HasOne(x => x.Container).WithMany(x => x.UserStories).HasForeignKey(x => x.ContainerId);
            Entity.HasOne(x => x.Creator).WithMany(x => x.CreatedUserStories).HasForeignKey(x => x.CreatedBy);
            Entity.HasOne(x => x.Assigned).WithMany(x => x.AssignedToUserStories).HasForeignKey(x => x.AssignedTo);
            Entity.HasMany(x => x.Tasks).WithOne(x => x.UserStory).HasForeignKey(x => x.UserStoryId);
        }
    }
}
