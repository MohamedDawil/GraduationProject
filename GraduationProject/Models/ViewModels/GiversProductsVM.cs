using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class GiversProductsVM
    {
        [Display(Name ="Bokade")]
        public GiversClaimedVM[] Claimed { get; set; }
        [Display(Name = "Ej bokade")]
        public GiversClaimedVM[] Unclaimed { get; set; }
    }
}
