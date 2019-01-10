using GraduationProject.Json;
using GraduationProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.RegularExpressions;
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

        public async Task<MembersProfileVM> GetProfile(ClaimsPrincipal user)
        {
            var result = await GetUser(user);

            return new MembersProfileVM
            {
                City = result.City,
                Street = result.Street,
                ZipCode = result.ZipCode,
                Email = result.Email,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Picture = result.Picture
            };
        }

        public async Task ChangeProfile(MembersProfileVM membersProfileVM, ClaimsPrincipal user)
        {
            var result = await GetUser(user);

            result.City = membersProfileVM.City;
            result.Email = membersProfileVM.Email;
            result.UserName = membersProfileVM.Email;
            result.FirstName = membersProfileVM.FirstName;
            result.LastName = membersProfileVM.LastName;

            if (!string.IsNullOrWhiteSpace(membersProfileVM.Picture))
                result.Picture = membersProfileVM.Picture;

            result.Street = membersProfileVM.Street;
            result.ZipCode = membersProfileVM.ZipCode;

            await userManager.UpdateAsync(result);
        }

        public async Task <Tuple <bool, string>> CheckAddress(MembersProfileVM membersProfileVM)
        {
            var http = new HttpClient();
            var street = new String(membersProfileVM.Street.Where(Char.IsLetter).ToArray());
            var streetNumber = Regex.Match(membersProfileVM.Street, @"\d+").Value;
            var url = string.Format($"https://papapi.se/json/?v={street}|{streetNumber}|{membersProfileVM.ZipCode}|{membersProfileVM.City}&token=b5d95cb8932150b6bb65e4de000fe4567aac2d30");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<Rootobject>(result); // Convertor from string"result" to json

            return new Tuple<bool, string>
            (
                json.result.status.code == "100",
                json.result.status.description_sv
            );
            
        }
    }
}
