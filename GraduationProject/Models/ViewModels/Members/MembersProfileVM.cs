using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class MembersProfileVM
    {
        public IFormFile FilePath { get; set; }
        public string Picture { get; set; }
        
        public string ErrorMessage { get; set; }
        [Required]
        [Display(Name = "Förnamn: ")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Efternamn: ")]
        public string LastName { get; set; }
        [Display(Name = "Gatuadress: ")]
        public string Street { get; set; }
        [Display(Name = "Postnr: ")]
        [RegularExpression(@"\d{3}[ ]?\d{2}")]
        public string ZipCode { get; set; }
        [Display(Name = "Postort: ")]
        public string City { get; set; }
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
