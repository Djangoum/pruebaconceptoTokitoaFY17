using IssuesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<IssuesManagerUser> GetSingle(string UserName);
        Task SignInAsync(IssuesManagerUser user, string Password, bool remember);
        Task Create(IssuesManagerUser user, string Password);
        Task<string> GenerateEmailConfirmation(IssuesManagerUser user);
        Task ConfirmEmailAsync(IssuesManagerUser user, string Token);
        Task DeleteAsync(IssuesManagerUser user);
        Task AddToRoleAsync(IssuesManagerUser user, string RoleName);
        Task<IssuesManagerUser> GetSingle(int UserId);
    }
}
