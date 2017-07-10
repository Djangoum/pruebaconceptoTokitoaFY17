using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using IssuesManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using XCutting.Extensions;
using Entities.IssuesManager;

namespace DataLayer.Context
{
    public class IdentityContext : IdentityDbContext<IssuesManagerUser, IssuesManagerRole, int>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.GetConfigurationsFromAssembly<IdentityContext>();
            modelBuilder.DisableCascadeDeleteConvention();
        }
        public DbSet<Log> Logs { get; set; }
    }
}
