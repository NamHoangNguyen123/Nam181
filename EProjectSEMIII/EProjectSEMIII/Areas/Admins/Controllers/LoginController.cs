using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using EProjectSEMIII.Areas.Admins.Models;
using EProjectSEMIII.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace EProjectSEMIII.Areas.Admins.Controllers
{
    [Area("Admins")]
    [Route("Admins")]
    public class LoginController : Controller
    {
        private readonly AppDBContext _context;

        public LoginController(AppDBContext context)
        {
            _context = context;
        }
        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginAdmin model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var data = _context.Admin.FirstOrDefault(a => a.UserName == model.UserName && a.Password == Encoding.EncryptData(model.Password) && a.Status == 0);

            if (data==null)
            {
                ModelState.AddModelError("CustomError", "Incorrect Username or Password!");
                return View(model);
            }

            HttpContext.Session.SetString("AdminNameLogin", data.AdminName);
            HttpContext.Session.SetInt32("AdminIdLogin", data.AdminId);

            return Redirect("/admins");
        }
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminNameLogin");
            HttpContext.Session.Remove("AdminIdLogin");
            return RedirectToAction(nameof(Login));
        }
    }
}
