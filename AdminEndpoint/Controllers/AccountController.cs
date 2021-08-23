using AdminEndpoint.Models;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index(string returnUrl = null)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "User", new { area = "User", returnUrl = returnUrl });
            return View();
        }
        [Route("Login/{returnUrl?}")]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                if (await _userManager.IsInRoleAsync(user,"Admin"))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }

            ViewData["returnUrl"] = returnUrl;
            return View();
        }
        public async Task<IActionResult> SignedIn(LoginViewModel model, string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            ViewData["returnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                                return Redirect(returnUrl);
                         
                            return RedirectToAction("Login", "Account");
                }

                if (result.IsLockedOut)
                {
                    ViewData["ErrorMessage"] = "اکانت شما به دلیل پنج بار ورود ناموفق به مدت پنج دقیق قفل شده است";
                    return View(model);
                }

                ModelState.AddModelError("", "رمزعبور یا نام کاربری اشتباه است");
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return Json(true);
            return Json("ایمیل وارد شده از قبل موجود است");
        }
        public async Task<IActionResult> IsUserNameInUse(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return Json(true);
            return Json("نام کاربری وارد شده از قبل موجود است");
        }

        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registerpost(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = true,
                    FullName = "ramin"

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var getUser = await _userManager.FindByNameAsync(user.UserName);
                    if (getUser != null)
                    {
                        var addRole = await _userManager.AddToRoleAsync(getUser, "Admin");
                        if (result.Succeeded)
                        {
                            var emailConfirmationToken =
                            await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            var emailMessage =
                            Url.Action("ConfirmEmail", "User",
                            new { username = user.UserName, token = emailConfirmationToken }, Request.Scheme);
                            //  await _messageSender.SendEmailAsync(model.Email, "Email confirmation", emailMessage);
                            return RedirectToAction("Index", "Dashboard", new { Area = "" });
                        }
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Register", model);
        }
    }
}
