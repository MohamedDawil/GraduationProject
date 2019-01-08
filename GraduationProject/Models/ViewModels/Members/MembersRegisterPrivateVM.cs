using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class MembersRegisterPrivateVM
    {
        [Required]
        [Display(Name = "Förnamn: ")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Efternamn: ")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "E-mail: ")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Lösenord: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Bekräfta lösenord: ")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Dina lösenord matchar inte... Lol")]
        public string ConfirmPassword { get; set; }
    }
}
