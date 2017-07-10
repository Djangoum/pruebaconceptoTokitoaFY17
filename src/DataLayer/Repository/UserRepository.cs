using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IssuesManager.Models;
using IssuesManager.Security;

namespace DataLayer.Repository
{
    using Context;
    using Interfaces;
    using Microsoft.AspNetCore.Http;
    using XCutting.Exceptions;

    public class UserRepository : IUserRepository
    {
        private readonly IdentityContext db;
        private readonly UserManager<IssuesManagerUser> userManager;
        private readonly SignInManager<IssuesManagerUser> loginManager;

        public UserRepository(IdentityContext db, UserManager<IssuesManagerUser> userManager,
               SignInManager<IssuesManagerUser> loginManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.loginManager = loginManager;
        }

        public async Task SignInAsync(IssuesManagerUser user, string Password, bool remember)
        {
            if (user == null)
                throw new ArgumentNullException();

            if (!user.EmailConfirmed)
                throw new UserNotConfirmedException();

            var loginResult = await loginManager.PasswordSignInAsync(user, Password, remember, false);

            if (!loginResult.Succeeded)
                throw new UserLoginException("");
        }

        public async Task<IssuesManagerUser> GetSingle(string UserName)
        {
            return await userManager.FindByNameAsync(UserName);
        }
        
        public async Task<IssuesManagerUser> GetSingle(int UserId)
        {
            return await userManager.FindByIdAsync(UserId.ToString());
        }

        public async Task<string> GenerateEmailConfirmation(IssuesManagerUser user)
        {
            return await userManager.
                 GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task DeleteAsync(IssuesManagerUser user)
        {
            if (user == null)
                throw new ArgumentNullException();

            await userManager.DeleteAsync(user);
        }

        public async Task Create(IssuesManagerUser user, string Password)
        {
            if (user == null) throw new ArgumentNullException();

            var result = await userManager.CreateAsync(user, Password);

            if ((!result.Succeeded)) throw new UserCreationException();
        }

        public async Task AddToRoleAsync(IssuesManagerUser user, string RoleName)
        {
            if (user == null || string.IsNullOrEmpty(RoleName))
                throw new ArgumentNullException();

            await userManager.AddToRoleAsync(user, RoleName);
        }

        public async Task ConfirmEmailAsync(IssuesManagerUser user, string Token)
        {
            if (user == null)
                throw new ArgumentNullException();

            var ConfirmationResult = await userManager.ConfirmEmailAsync(user, Token);

            if (!ConfirmationResult.Succeeded)
                throw new EmailConfirmationException();
        }
    }
}