using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using IssuesManager.Models;
using IssuesManager.Security;
using System;
using System.Threading.Tasks;
using XCutting.Exceptions;

namespace BusinessLayer.BussinesObjects
{
    public class UserBusinessObject : IUserBusinessObject
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserBusinessObject(IUserRepository UserRepository, IRoleRepository RoleRepository)
        {
            _userRepository = UserRepository;
            _roleRepository = RoleRepository;
        }

        public async Task SignIn(string UserName, string Password, bool Remember)
        {
            IssuesManagerUser user = await _userRepository.GetSingle(UserName);

            await _userRepository.SignInAsync(user, Password, Remember);
        }

        public async Task<string> GenerateEmailConfirmationToken(IssuesManagerUser user)
        {
            return await _userRepository.GenerateEmailConfirmation(user);
        }

        public async Task Add(IssuesManagerUser user, string Password)
        {
            await _userRepository.Create(user, Password);

            if(!await _roleRepository.RoleExistsAsync(RolesDefinition.Guest))
            {
                IssuesManagerRole role = new IssuesManagerRole();
                role.Name = RolesDefinition.Guest;

                bool Success = await _roleRepository.CreateAsync(role);
                if(!Success)
                {
                    await _userRepository.DeleteAsync(user);
                    throw new RoleCreationException();
                }
            }

            await _userRepository.AddToRoleAsync(user, RolesDefinition.Guest);
        }

        public async Task ConfirmEmailAsync(int UserId, string Token)
        {
            IssuesManagerUser user = await _userRepository.GetSingle(UserId);

            await _userRepository.ConfirmEmailAsync(user, Token);
        }
    }
}
