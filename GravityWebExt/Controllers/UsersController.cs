using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GravityWebExt.Models;
using GravityWebExt.ViewModels;

namespace GravityWebExt.Controllers
{
    public class UsersController : Controller
    {
        UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.Name };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
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
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Name = user.UserName, isLogIn = true };
            return View(model);
        }
        /// <summary>
        /// Редактирование выбранного пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [RequireRequestValue("id")]
        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Name = user.UserName, isLogIn = false };
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
                    IdentityResult result;
                    bool ok = true;
                    if (model.ChangePassword)
                    {
                        result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                        if (!result.Succeeded)
                        {
                            ok = false;
                            foreach (var error in result.Errors)
                                ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                    user.UserName = model.Name;
                    result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded && ok)
                    {
                        if (model.isLogIn)
                            return RedirectToAction("Logout", "Account");
                        else
                            return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                            ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

    }
}