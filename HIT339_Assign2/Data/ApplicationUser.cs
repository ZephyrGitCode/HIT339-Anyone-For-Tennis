using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HIT339_Assign2.Data;
using Microsoft.AspNetCore.Identity;

namespace HIT339_Assign2.Areas.Identity.Data
{
    // Add profile data for ApplicationUser users by adding properties to the Assign1_Salesboard_ZephyrUser class
    public class ApplicationUser : IdentityUser
    {
        [StringLength(25), PersonalData]
        public string Fname { get; set; }

        [StringLength(50), PersonalData]
        public string Lname { get; set; }

        [Range(16,120), PersonalData]
        public int Age { get; set; }

        [PersonalData]
        public string Gender { get; set; }

        [PersonalData]
        public string Biography { get; set; }

        public virtual ICollection<Enrolment> Enrolments { get; set; }
    }
}