using IssuesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.IssuesManager
{
    public class UserStory : BaseDao<int>
    {
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public int AssignedTo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public decimal Estimation { get; set; }
        public int ContainerId { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual IssuesManagerUser Creator { get; set; }
        public virtual IssuesManagerUser Assigned { get; set; }
        public virtual UserStoryContainer Container { get; set; }
    }
}
