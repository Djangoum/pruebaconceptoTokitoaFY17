using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using XCutting.ModelBuilderExtensions;
using DataLayer.Context;
using Entities.IssuesManager;

namespace DataLayer.Mappings
{
    public class TaskMapping : BaseMapping<Task>, IEntityConfiguration<IssuesManagerContext>
    {
        public TaskMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure()
        {
            Entity.HasKey(x => x.Id);
            Entity.Property(x => x.Title).IsRequired().HasMaxLength(300);
            Entity.Property(x => x.Description).IsRequired();
            Entity.HasOne(x => x.Creator).WithMany(x => x.CreatedTasks).HasForeignKey(x => x.CreatedBy);
            Entity.HasOne(x => x.Assigned).WithMany(x => x.AssignedToTasks).HasForeignKey(x => x.AssignedTo);
            Entity.HasOne(x => x.UserStory).WithMany(x => x.Tasks).HasForeignKey(x => x.UserStoryId);
        }
    }
}
