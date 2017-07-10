using Entities.IssuesManager;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IssuesManager.Models
{
    public class IssuesManagerUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public DateTime RegisterDate {get; set;}
        public virtual ICollection<Project> ManagedProjects { get; set; } 
        public virtual ICollection<UserStory> CreatedUserStories { get; set; }
        public virtual ICollection<UserStory> AssignedToUserStories { get; set; }
        public virtual ICollection<Task> CreatedTasks { get; set; }
        public virtual ICollection<Task> AssignedToTasks { get; set; }
    }
}
