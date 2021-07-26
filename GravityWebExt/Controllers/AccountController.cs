using GravityWebExt.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GravityWebExt.Controllers
{
    public class AccountController : Controller
    {
        private AuthContext _context;
        public AccountController(AuthContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserAccount user = await _context.Users.FirstOrDefaultAsync(u => u.Name == model.Name);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new UserAccount { Name = model.Name, Password = model.Password };
                    UserGroup userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Такой пользователь уже существует!");
            }
            else
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserAccount user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Name == model.Name && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация
                    return RedirectToAction(GetPrevPage(), "Home");
                }
                ModelState.AddModelError("", "Неверные логин и(или) пароль");
            }
            return View(model);
        }
        private async Task Authenticate(UserAccount user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(GetPrevPage(), "Home");
        }

        public string GetPrevPage()
        {
            string mask = "%2FHome%2F";
            string referer = new Uri(Request.Headers["Referer"].ToString()).Query;
            return referer.Length == 0 ? "Index" : referer[(referer.IndexOf(mask) + mask.Length)..];
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserAccount user = await _context.Users.FirstOrDefaultAsync(u => u.Name == model.Name);
                if (user != null)
                {
                    // изменяем поля пользователя в бд
                    user.Password = model.Password;

                    await _context.SaveChangesAsync();
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    return RedirectToAction("Login", "Account");
                }
                ModelState.AddModelError("", "Пользователь не найден");
            }
            else
                ModelState.AddModelError("", "Пароли не совпадают!");
            return View(model);
        }

    }
}
