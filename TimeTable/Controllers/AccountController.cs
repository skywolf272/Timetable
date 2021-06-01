using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTable.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TimeTable.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace TimeTable.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDBContext appDB;
        private readonly UserManager<UserStudent> userManager;
        private readonly SignInManager<UserStudent> signInManager;

        public AccountController( AppDBContext dBContext, UserManager<UserStudent> _userManager, SignInManager<UserStudent> _signInManager)
        {
            appDB = dBContext;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserModel loginUserModel)
        {
            if(ModelState.IsValid)
            {
                UserStudent user1 = await userManager.FindByNameAsync(loginUserModel.UserName);
                if (user1 != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user1, loginUserModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        if (userManager.IsInRoleAsync(user1, "student").Result)
                        {
                            return RedirectToAction("Courses", "Student", new { area = "student" });
                        }
                        else if(userManager.IsInRoleAsync(user1, "teacher").Result)
                        {
                            return RedirectToAction("Courses","Teacher", new { area = "teacher" });
                        }
                        else if (userManager.IsInRoleAsync(user1, "admin").Result)
                        {
                            return RedirectToAction("Courses", "Admin", new { area = "admin" });
                        }
                    }
                }
                ModelState.AddModelError(nameof(loginUserModel), "Неверный логин или пароль");
            }
            return View(loginUserModel);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationUserModel registerModel)
        {
            if (ModelState.IsValid)
            {
                UserStudent user = new UserStudent { FirstName = registerModel.FirstName, SecondName = registerModel.SecondName, UserName = registerModel.UserName };
                // добавляем пользователя
                var result = await userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await signInManager.SignInAsync(user, false);
                    await userManager.AddToRoleAsync(user, "student"); //TODO: создать роли
                    appDB.SaveChanges();
                    return RedirectToAction("", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
