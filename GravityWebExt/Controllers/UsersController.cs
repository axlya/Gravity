using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GravityWebExt.Models;
using GravityWebExt.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace GravityWebExt.Controllers
{
    public class UsersController : Controller
    {
        UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            // получем список ролей пользователя
            _userManager = userManager;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }
        /// <summary>
        /// Редактирование текущего пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name??"");
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Name = user.UserName, isLogIn = true, ChangePassword = true };
            return View(model);
        }
        /// <summary>
        /// Редактирование выбранного пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [RequireRequestValue("id")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Name = user.UserName, isLogIn = false, ChangePassword = true };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    bool isPassChange = false;
                    bool isLoginChange = false;
                    if (user.UserName != model.Name)
                    {
                        if (user.UserName == "admin")
                        {
                            ModelState.AddModelError(string.Empty, "Не может быть изменено имя администратора");
                        }
                        else
                        {
                            user.UserName = model.Name;
                            IdentityResult result = await _userManager.UpdateAsync(user);
                            if (result.Succeeded)
                            {
                                isLoginChange = true;
                            }
                            else
                            {
                                foreach (var error in result.Errors)
                                    ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }
                    if (model.ChangePassword)
                    {
                        if (model.OldPassword == null)
                            model.OldPassword = "";
                        if (model.NewPassword == null)
                            model.NewPassword = "";
                        IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                        if (result.Succeeded)
                        {
                            isPassChange = true;
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                                ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }

                    if (ModelState.ErrorCount == 0)
                    {
                        if (model.isLogIn)
                        {
                            if (isPassChange || isLoginChange)
                                return RedirectToAction("Logout", "Account");
                            else
                                return RedirectToAction("Index", "Home");
                        }
                        else
                            return RedirectToAction("Index");
                    }

                }
            }
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (user.UserName == "admin")
                {

                }
                else
                {
                    IdentityResult result = await _userManager.DeleteAsync(user);
                }
            }
            return RedirectToAction("Index");
        }

    }
}