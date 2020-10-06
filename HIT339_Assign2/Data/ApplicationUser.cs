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
        [Display(Name = "First Name")]
        [StringLength(25), PersonalData]
        public string Fname { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50), PersonalData]
        public string Lname { get; set; }

        [Display(Name = "Age")]
        [Range(15,120), PersonalData]
        public int Age { get; set; }

        [Display(Name = "Gender")]
        [PersonalData]
        public string Gender { get; set; }

        [Display(Name = "Biography")]
        [PersonalData]
        public string Biography { get; set; }

        [Display(Name = "Enrolments")]
        public virtual ICollection<Enrolment> Enrolments { get; set; }
    }
}