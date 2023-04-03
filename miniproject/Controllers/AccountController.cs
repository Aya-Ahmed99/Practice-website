using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using miniproject.Models;
using miniproject.viewModel;
using System.Security.Claims;

namespace miniproject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Register(RegisterVM registerVM )
        {
            if(ModelState.IsValid == true) 
            {
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = registerVM.UserName;
                userModel.PasswordHash = registerVM.Password;
                IdentityResult result = await userManager.CreateAsync(userModel , userModel.PasswordHash);
                if(result.Succeeded ) 
                {
                   await userManager.AddToRoleAsync(userModel, "Student");
                    //create cookie
                   //await signInManager.SignInAsync(userModel , false);
                   
                    //add extra claims 
                    List<Claim> addClaim = new List<Claim>();
                    addClaim.Add(new Claim("Intake No", "43"));
                    //store clime in database
                    //userManager.AddClaimsAsync(userModel, addClaim);
                    await signInManager.SignInWithClaimsAsync(userModel, false, addClaim);
                    return RedirectToAction("GetAll", "Instractor");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                }
            }
            return View(registerVM);

        }
    
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(ModelState.IsValid)
            {
               ApplicationUser user = await userManager.FindByNameAsync(loginVM.UserName);
               
                if(user != null)
                {
                   await signInManager.PasswordSignInAsync(user, loginVM.Password , loginVM.RememebrMe , false);
                    return RedirectToAction("GetAll", "Instractor");
                }else
                {
                    ModelState.AddModelError("", "UserName Or Password Wrong");
                }
            
            }
            return View(loginVM);
        }


        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
