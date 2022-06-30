using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {

       
            UserDAL u = new UserDAL();
            [HttpGet]
        public IActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
            public IActionResult SignUp(IFormCollection form)
            {
                User u = new User();
                u.User_FullName = form["Name"].ToString();
                u.EmailId = form["Email"].ToString();
                u.Password = form["Password"].ToString();
                u.RoleId = 2;
                int res = u.Save(u);

                return View();

            }
            [HttpGet]
            public IActionResult SignIn()
            {
                return View();
            }
            [HttpPost]
            public IActionResult SignIn(IFormCollection form)
            {
                User u = new User();
                u.EmailId = form["Email"].ToString();
                u.Password = form["Password"].ToString();
                bool res = u.Verify(u);
                if (res == true)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ViewBag.Message = "Invalid Entry";
                    return View();
                }
            }
            public IActionResult Invalid()
            {
                TempData["alertMessage"] = "Invalid Email-id or Password";
                return View();
            }




        }
    }

