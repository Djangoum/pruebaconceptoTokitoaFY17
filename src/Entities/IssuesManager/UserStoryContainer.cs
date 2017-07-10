using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.IssuesManager
{
    public class UserStoryContainer : BaseDao<int>
    {
        public int ProjectId { get; set; }
        public UserStoryContainerType Type { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<UserStory> UserStories { get; set; }
    }
}
