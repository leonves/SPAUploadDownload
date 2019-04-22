using ApiLTMTest.Application.Service;
using ApiLTMTest.Application.Service.Interfaces;
using ApiLTMTest.Application.ViewModel;
using ApiLTMTest.Application.ViewModel.User;
using ApiLTMTest.Domain.Enums;
using ApiLTMTest.Host.Controllers.Base;
using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiLTMTest.Host.Controllers
{
    [Authorize, RoutePrefix("User")]
    public class UserController : BaseController
    {

        private IUserService UserService { get; }


        public UserController(IUserService userService)
        {
            UserService = userService;
        }


        [HttpPost]
        [AllowAnonymous, Route(nameof(Register))]
        public async Task<IHttpActionResult> Register(RegisterVM registerVM)
        {
            try
            {
                var result = await UserService.RegisterAsync(registerVM);

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Authorize, Route(nameof(GetUserInfo))]
        public async Task<IHttpActionResult> GetUserInfo()
        {
            try
            {
                var result = await UserService.GetUserInfoAsync(CurrentUserID);

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Authorize, Route(nameof(UpdatePassword))]
        public async Task<IHttpActionResult> UpdatePassword(UpdatePasswordVM updatePasswordVM)
        {
            try
            {
                var result = await UserService.UpdatePasswordAsync(CurrentUserID, updatePasswordVM);

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Authorize, Route(nameof(UpdateUser))]
        public async Task<IHttpActionResult> UpdateUser(UserVM userVM)
        {
            try
            {
                var result = await UserService.UpdateUserAsync(CurrentUserID, userVM);

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
