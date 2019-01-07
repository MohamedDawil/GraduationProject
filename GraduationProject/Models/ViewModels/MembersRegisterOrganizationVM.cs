using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class MembersRegisterOrganizationVM
    {
        [Required]
        [Display(Name = "Organisationsnamn: ")]
        public string OrgName { get; set; }
        [Required]
        [Display(Name = "Organisationsnummer: ")]
        public string OrgNumber { get; set; }
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
        public string ConfirmPassword { get; set; }
    }
}
