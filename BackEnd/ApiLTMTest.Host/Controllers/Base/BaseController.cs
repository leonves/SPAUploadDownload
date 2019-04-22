using ApiLTMTest.Application.ViewModel;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Web.Http;

namespace ApiLTMTest.Host.Controllers.Base
{
    public abstract class BaseController : ApiController
    {
        protected string CurrentUserID
        {
            get
            {
                return User.Identity.GetUserId();
            }
        }

        protected IHttpActionResult DoResponse<T>(RequestReturnVM<T> result)
        {
            if (result.Success)
                return Ok(result);
            else
                return Content(HttpStatusCode.BadRequest, result);
        }
    }
}
