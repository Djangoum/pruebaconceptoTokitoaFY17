using DataLayer.Interfaces;
using IssuesManager.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IssuesManagerRole> _roleManager;

        public RoleRepository(RoleManager<IssuesManagerRole> RoleManager)
        {
            _roleManager = RoleManager;
        }

        public async Task<bool> RoleExistsAsync(string RoleName)
        {
            return await _roleManager.RoleExistsAsync(RoleName);
        }

        public async Task<bool> CreateAsync(IssuesManagerRole Role)
        {
            return (await _roleManager.CreateAsync(Role)).Succeeded;         
        }
    }
}
