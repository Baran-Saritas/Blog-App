using Microsoft.AspNetCore.Mvc;
using Mvc_Tekrar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Tekrar.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            using (var context = new Context())
            {

                var hashPassword = user.Mail + user.Password;
                using (HashAlgorithm algorithm = SHA256.Create())
                {
                    var hash = Encoding.UTF8.GetBytes(hashPassword);



                    var sb = new StringBuilder();
                    foreach (var h in hash)
                    {
                        sb.Append(h.ToString("X2"));
                    }

                    user.Password = sb.ToString();


                    ViewBag.Login = true;
                    var sonuc = context.User.Where(t => t.Mail == user.Mail && t.Password == user.Password).SingleOrDefault();
                    if (sonuc != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Login = false;
                        return View();
                    }
                }
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            ViewBag.Register = true;
            using (var context = new Context())
            {


                var hashPassword = user.Mail + user.Password;
                using (HashAlgorithm algorithm = SHA256.Create())
                {
                    var hash = Encoding.UTF8.GetBytes(hashPassword);



                    var sb = new StringBuilder();
                    foreach (var h in hash)
                    {
                        sb.Append(h.ToString("X2"));
                    }

                    user.Password = sb.ToString();


                    var sonuc = context.User.Where(t => t.Mail == user.Mail && t.Password == user.Password).SingleOrDefault();
                    if (sonuc == null && user.Mail != null && user.Password != null)
                    {


                        context.Add(user);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {

                        ViewBag.Register = false;

                        return View();
                    }

                }
            }
        }
    }
}
