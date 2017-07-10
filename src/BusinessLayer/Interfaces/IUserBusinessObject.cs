using IssuesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserBusinessObject
    {
        Task SignIn(string UserName, string Password, bool Remember);
        Task Add(IssuesManagerUser user, string Password);
        Task ConfirmEmailAsync(int UserId, string Token);
        Task<string> GenerateEmailConfirmationToken(IssuesManagerUser user);
    }
}
