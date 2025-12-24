using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager
            , AppDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                ModelState.AddModelError("", "Email already exists");
                return View(model);
            }

            var user = new ApplicationUser
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.Email,
                Address = model.Address
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                 await _userManager.AddToRoleAsync(user, "User");
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var appuser = await _userManager.FindByEmailAsync(model.Email);
                if (appuser != null)
                {
                    var result = await _userManager.CheckPasswordAsync(appuser, model.Password);
                    if (result)
                    {
                        await _signInManager.SignInAsync(appuser, isPersistent: model.RememberMe);
                        return RedirectToAction("Index", "Product");
                    }

                }
                ModelState.AddModelError("", "Email Or Passwword is Invalid");
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult VerfiyEmail()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> VerfiyEmail(VerifyEmailViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.EmailAddress);
                if (user != null)
                {
                    string email = model.EmailAddress;
                    return RedirectToAction("ChangePassword", "Account", new {email=model.EmailAddress});
                }
            }


            ModelState.AddModelError("", "Email Is Not Found");
            return View(model);

        }
        [HttpGet]
        public IActionResult ChangePassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("VerfiyEmail");
            }

            return View(new ChangePasswrodViewModel { EmailAddress = email });
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswrodViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.EmailAddress);
                if (user != null)
                {
                    var result = await _userManager.RemovePasswordAsync(user);
                    if (result.Succeeded)
                    {
                        var result2 = await _userManager.AddPasswordAsync(user, model.NewPassword);
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);

                        }
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email Is Not Found");
                    return View(model);
                }
            }
            ModelState.AddModelError("", "Something Went Wrong");
            return View(model);
        }
        }
    }

