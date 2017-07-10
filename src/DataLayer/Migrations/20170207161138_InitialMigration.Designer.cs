using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DataLayer.Context;
using Entities.IssuesManager;

namespace DataLayer.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20170207161138_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.IssuesManager.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("LogLevel");

                    b.Property<string>("Message");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Entities.IssuesManager.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BeginningDate");

                    b.Property<decimal>("ConsumedHours");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("SqlServer:ComputedColumnSql", "GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<decimal>("HoursEstimation");

                    b.Property<int>("ManagerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Entities.IssuesManager.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssignedTo");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime?>("End");

                    b.Property<decimal>("Estimation");

                    b.Property<DateTime?>("Start");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<int>("UserStoryId");

                    b.HasKey("Id");

                    b.HasIndex("AssignedTo");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UserStoryId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("Entities.IssuesManager.UserStory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssignedTo");

                    b.Property<int>("ContainerId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime?>("End");

                    b.Property<decimal>("Estimation");

                    b.Property<DateTime?>("Start");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("AssignedTo");

                    b.HasIndex("ContainerId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("UserStory");
                });

            modelBuilder.Entity("Entities.IssuesManager.UserStoryContainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("UserStoryContainer");
                });

            modelBuilder.Entity("IssuesManager.Models.IssuesManagerRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("IssuesManager.Models.IssuesManagerUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Entities.IssuesManager.Project", b =>
                {
                    b.HasOne("IssuesManager.Models.IssuesManagerUser", "Manager")
                        .WithMany("ManagedProjects")
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("Entities.IssuesManager.Task", b =>
                {
                    b.HasOne("IssuesManager.Models.IssuesManagerUser", "Assigned")
                        .WithMany("AssignedToTasks")
                        .HasForeignKey("AssignedTo");

                    b.HasOne("IssuesManager.Models.IssuesManagerUser", "Creator")
                        .WithMany("CreatedTasks")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Entities.IssuesManager.UserStory", "UserStory")
                        .WithMany("Tasks")
                        .HasForeignKey("UserStoryId");
                });

            modelBuilder.Entity("Entities.IssuesManager.UserStory", b =>
                {
                    b.HasOne("IssuesManager.Models.IssuesManagerUser", "Assigned")
                        .WithMany("AssignedToUserStories")
                        .HasForeignKey("AssignedTo");

                    b.HasOne("Entities.IssuesManager.UserStoryContainer", "Container")
                        .WithMany("UserStories")
                        .HasForeignKey("ContainerId");

                    b.HasOne("IssuesManager.Models.IssuesManagerUser", "Creator")
                        .WithMany("CreatedUserStories")
                        .HasForeignKey("CreatedBy");
                });

            modelBuilder.Entity("Entities.IssuesManager.UserStoryContainer", b =>
                {
                    b.HasOne("Entities.IssuesManager.Project", "Project")
                        .WithMany("UserStoryContainers")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("IssuesManager.Models.IssuesManagerRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("IssuesManager.Models.IssuesManagerUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("IssuesManager.Models.IssuesManagerUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<int>", b =>
                {
                    b.HasOne("IssuesManager.Models.IssuesManagerRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("IssuesManager.Models.IssuesManagerUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });
        }
    }
}
