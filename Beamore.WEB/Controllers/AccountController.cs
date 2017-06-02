
using Beamore.Contracts.DataTransferObjects.Account;
using Beamore.WEB.Helper;
using Beamore.WEB.Models;
using Beamore.WEB.Service;
using Beamore.WEB.Service.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Beamore.WEB.Controllers
{
    public class AccountController : Controller
    {
        private DataClient service = new DataClient();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid && model != null)
            {
                model.Role = "Manager";
                var rt = await service.Register(model);
                if (rt.IsSuccess)
                {
                    return RedirectToAction("Login", "Account");
                }
                ViewBag.error = rt.Message;

            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                model.grant_type = "password";
                var rs = await service.Login(model);
                if (rs != null)
                {
                    HttpContext.Session["token"] = rs.access_token;
                    var cl = new ServiceClient(rs.access_token);
                    var usr = await cl.GetUser();
                    Session["Username"] = usr.Username;
                    Session["Email"] = usr.Email;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.error = "Wrong email or password please try again ";
            }
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ResetPassword(ForgotPasswordDTO model)
        {
            if (ModelState.IsValid && model != null)
            {
                var rt = await service.ResetPassword(model);
                if (rt.IsSuccess)
                {
                    ViewBag.reset = rt.Message;
                    return View();
                }
                ViewBag.error = rt.Message;
            }
            return View();
        }

        // GET: Account
        public ActionResult Index()
        {
            if (TempData["fail"] != null)
                ViewBag.fail = TempData["fail"];
            if (TempData["Success"] != null)
                ViewBag.Success = TempData["Success"];
            return View();
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword(string key)
        {
            var data = new ForgotPasswordModel
            {
                GuidPassword = key
            };
            return View(data);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var rt = await service.UpdatePassword(model);
                if (rt)
                {
                    TempData["Success"] = "Your password is updated.";
                    return RedirectToAction("Index", "Account");
                }
            }

            TempData["fail"] = "Opps. There is a error. Please try again";

            return RedirectToAction("Index", "Account");
        }
    }
}