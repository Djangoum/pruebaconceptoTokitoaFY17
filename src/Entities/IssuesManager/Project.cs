using IssuesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.IssuesManager
{
    public class Project : BaseDao<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? BeginningDate { get; set; }
        public decimal HoursEstimation { get; set; }
        public decimal ConsumedHours { get; set; }
        public int ManagerId { get; set; }
        public virtual IssuesManagerUser Manager { get; set; }
        public ICollection<UserStoryContainer> UserStoryContainers { get; set; }
    }
}