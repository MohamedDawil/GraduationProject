using GraduationProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GraduationProject.Models
{
    public class MembersService
    {
        private UserManager<MyIdentityUser> userManager;
        private SignInManager<MyIdentityUser> signInManager;
        private RoleManager<IdentityRole> roleManager;
        //private MembersContext context;

        public MembersService(UserManager<MyIdentityUser> userManager, SignInManager<MyIdentityUser> signInManager, RoleManager<IdentityRole> roleManager/*, MembersContext context*/)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            //this.context = context;
        }

        public async Task<MyIdentityUser> GetUser(ClaimsPrincipal user)
        {
            string userId = userManager.GetUserId(user);
            MyIdentityUser identityUser = await userManager.FindByIdAsync(userId);
            return identityUser;
        }

        public async Task<bool> SignInAsync(MembersIndexVM membersIndexVM)
        {
            var result = await signInManager.PasswordSignInAsync(membersIndexVM.Email, membersIndexVM.Password, false, false);
            return result.Succeeded;
        }

        public async Task<bool> CreateAsync(MembersRegisterPrivateVM membersRegisterPrivateVM)
        {
            var result = await userManager.CreateAsync(
                new MyIdentityUser
                {
                    UserName = membersRegisterPrivateVM.Email,
                    FirstName = membersRegisterPrivateVM.FirstName,
                    LastName = membersRegisterPrivateVM.LastName,
                    Email = membersRegisterPrivateVM.Email
                }, membersRegisterPrivateVM.Password);

            return result.Succeeded;
        }
    }
}
