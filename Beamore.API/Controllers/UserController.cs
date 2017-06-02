using Beamore.API.BusinessLogics.CO;
using Beamore.API.BusinessLogics.UnitOfWorks;
using Beamore.Contracts.DataTransferObjects.Account;
using Beamore.Contracts.DataTransferObjects;
using Beamore.DAL.Repositories;
using System.Web.Http;



namespace Beamore.API.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        /// <summary>
        /// Register Api
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public RegistrationResultDTO RegisterUser(RegisterDTO user)
        {
            AuthenticationService authenticate = new AuthenticationService(new UserRepo(), new TempUserRepo());
            RegistrationResultDTO response = authenticate.Register(user);
            return response;
        }

        [HttpPost]
        [Route("forgotpassword")]
        public ForgotPasswordResultDTO ForgetPassword(ForgotPasswordDTO model)
        {
            AuthenticationService authenticate = new AuthenticationService(new UserRepo(), new TempUserRepo());
            ForgotPasswordResultDTO result = authenticate.ForgotPassword(model);
            return result;
        }

        [HttpPost]
        [Route("updatepassword")]
        public bool UpdatePassword(UpdatePasswordCO model)
        {
            AuthenticationService authenticate = new AuthenticationService(new UserRepo(), new TempUserRepo());
            bool result = authenticate.UpdatePassword(model);
            return result;
        }      
        
        [Authorize(Roles ="endUser,Manager")]
        [HttpGet]
        [Route("userinfo")]
        public UserDTO GetUserDetail()
        {
            AuthenticationService authenticate = new AuthenticationService(new UserRepo(), new TempUserRepo());
            return authenticate.UserInformation(this.User.Identity.Name);
        }
    }
}
