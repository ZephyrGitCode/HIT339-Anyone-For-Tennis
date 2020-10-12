using HIT339_Assign2.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIT339_Assign2.Models
{
    public class UserViewModel
    {
        public List<ApplicationUser> Members { get; set; }

        public List<ApplicationUser> coaches { get; set; }

        public List<ApplicationUser> Admins { get; set; }
    }
}
