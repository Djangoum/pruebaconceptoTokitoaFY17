using IssuesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IRoleRepository
    {
        Task<bool> RoleExistsAsync(string RoleName);
        Task<bool> CreateAsync(IssuesManagerRole Role);
    }
}
