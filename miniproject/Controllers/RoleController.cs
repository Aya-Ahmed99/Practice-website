﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using miniproject.viewModel;

namespace miniproject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(RoleVM roleVM)
        {
            if(ModelState.IsValid) 
            {
                IdentityRole roleModel = new IdentityRole();
                roleModel.Name = roleVM.RoleName;
              IdentityResult identityResult = await roleManager.CreateAsync(roleModel);
            
                if(identityResult.Succeeded) 
                {
                    return RedirectToAction("Login" , "Account");
                }else
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                }
            }
            return View(roleVM);
        }
    }
}
