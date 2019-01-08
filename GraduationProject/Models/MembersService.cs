using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
