using EProjectSEMIII.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;

namespace EProjectSEMIII.Controllers
{
    [Route("")]
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
        public IActionResult Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var data = _context.CustomerRecord.SingleOrDefault(c => c.UserName == model.UserName && c.Password == Encoding.EncryptData(model.Password) && c.Status == 0);
            if (data==null)
            {
                ModelState.AddModelError("customError", "Incorrect Username or Password!");
                return View(model);
            }
            
            HttpContext.Session.SetString("UserNameLogin", data.UserName);
            HttpContext.Session.SetInt32("UserIdLogin", data.CustomerRecordId);

            return RedirectToAction("Index", "Home");
        }
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserNameLogin");
            HttpContext.Session.Remove("UserIdLogin");
            return RedirectToAction(nameof(Login));
        }
        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [Route("Register")]
        [HttpPost]
        public IActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var checkName = _context.CustomerRecord.FirstOrDefault(c => c.UserName.ToUpper() == model.UserName.ToUpper());
                    if (checkName != null)
                    {
                        ViewBag.CheckUserName = "UserName already exists";
                        return View(model);
                    }
                    if (model.Password != model.RePassword)
                    {
                        ViewBag.ErrorRePass = "Incorrect Re-enter password!";
                        return View(model);
                    }
                    CustomerRecord newAccount = new CustomerRecord();
                    newAccount.UserName = model.UserName;
                    newAccount.CustomerAdd = model.CustomerAdd;
                    newAccount.CustomerName = model.CustomerName;
                    newAccount.CustomerPhone = model.CustomerPhone;
                    newAccount.Password = Encoding.EncryptData(model.Password);
                    _context.Add(newAccount);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Login));
                }
                catch (Exception )
                {
                    ViewBag.error = "Can't create an account, please try again later or contact us!";
                    return View();
                }
            }
            return View(model);
            
        }
    }
}
