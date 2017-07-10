using BusinessLayer.Interfaces;
using Infrastructure.JsonResponses;
using IssuesManager.Models;
using IssuesManager.Tools;
using IssuesManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using XCutting.Exceptions;
using XCutting.Languages;

namespace IssuesManager.APIControllers
{
    [Route("/[controller]/[action]")]
    public class UserController : Controller
    {

        private readonly IUserUnitOfWork _UserUnitOfWork;
        private readonly IEmailService EmailService;

        public UserController(IUserUnitOfWork UserBusinessObject, IEmailService emailSender)
        {
            this._UserUnitOfWork = UserBusinessObject;
            this.EmailService = emailSender;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Login([FromBody]LoginViewModel data)
        {
            try
            {
                await _UserUnitOfWork.UserBussinesObject.SignIn(data.UserName, data.Password, data.Remember);

                return StandardJsonResult.Create(null).SetSuccess(LoginLanguajes.USERLOGEDIN);
            }
            catch(UserNotConfirmedException)
            {
                return StandardJsonResult.Create(null).SetError(LoginLanguajes.EMAILNOTCOFIRMED);
            }
            catch(UserLoginException ex)
            {
                return StandardJsonResult.Create(null).SetError(LoginLanguajes.SOMETHINGWENTBAD);
            }
            catch(ArgumentNullException)
            {
                return StandardJsonResult.Create(null).SetError(LoginLanguajes.USERNOTFOUND);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Register([FromBody] RegisterViewModel data)
        {
            try
            {
                IssuesManagerUser user = new IssuesManagerUser()
                {
                    UserName = data.UserName,
                    Email = data.Email,
                    FullName = data.Name,
                    RegisterDate = DateTime.Today,
                    EmailConfirmed = false
                };

                await _UserUnitOfWork.UserBussinesObject.Add(user, data.Password);

                string confirmationLink = Url.Action("ConfirmEmail",
                    "User", new
                    {
                        userid = user.Id,
                        token = await _UserUnitOfWork.UserBussinesObject.GenerateEmailConfirmationToken(user)
                    },
                    protocol: HttpContext.Request.Scheme);

                await EmailService.SendAsync(user.Email, "Confirm your IssuesManager Account", $"Follow this link to confirm your account, {confirmationLink} ");

                return StandardJsonResult.Create(null).SetSuccess(LoginLanguajes.USERREGISTERED);
            }
            catch (UserCreationException)
            {
                return StandardJsonResult.Create(null).SetError(LoginLanguajes.SOMETHINGWENTBAD);
            }
            catch(RoleCreationException)
            {
                return StandardJsonResult.Create(null).SetError(LoginLanguajes.SOMETHINGWENTBAD);
            }
            catch(ArgumentNullException)
            {
                return StandardJsonResult.Create(null).SetError(LoginLanguajes.SOMETHINGWENTBAD);
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(int userid, string token)
        {
            try
            {
                await _UserUnitOfWork.UserBussinesObject.ConfirmEmailAsync(userid, token);

                return RedirectToAction("Index", "Home");
            }
            catch(EmailConfirmationException)
            {
                return RedirectToAction("Index", "Home");
            }
            catch(Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}