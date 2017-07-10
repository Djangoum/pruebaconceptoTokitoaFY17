using DataLayer.Context;
using DataLayer.Interfaces;
using Entities;
using Entities.IssuesManager;
using IssuesManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using XCutting.ModelBuilderExtensions;

namespace DataLayer.Mappings
{
    public class ProjectMapping : BaseMapping<Project>, IEntityConfiguration<IssuesManagerContext>
    {
        public ProjectMapping(ModelBuilder builder) : base(builder) { }

        public void Configure()
        {
            Entity.Property(x => x.Description).IsRequired();
            Entity.Property(x => x.Name).HasMaxLength(300).IsRequired();
            Entity.HasKey(x => x.Id);
            Entity.Property(x => x.CreationDate).ForSqlServerHasComputedColumnSql("GETDATE()");
            Entity.HasOne(x => x.Manager).WithMany(x => x.ManagedProjects).HasForeignKey(x => x.ManagerId);
        }
    }
}
