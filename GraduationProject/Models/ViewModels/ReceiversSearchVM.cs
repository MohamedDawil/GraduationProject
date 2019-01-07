using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class ReceiversSearchVM
    {
        public string Search { get; set; }
        public int Distance { get; set; }
        public ReceiversProductVM[] Products { get; set; }

    }
}
