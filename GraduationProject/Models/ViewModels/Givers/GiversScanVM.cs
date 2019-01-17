using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class GiversScanVM
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public bool NotFound { get; set; }
    }
}
