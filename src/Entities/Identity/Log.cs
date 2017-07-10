using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.IssuesManager
{
    public class Log : BaseDao<int>
    {
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
