using HIT339_Assign2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HIT339_Assign2.Data
{
    public class Schedule
    {
        public int Id { get; set; }

        [StringLength(50), PersonalData]
        public string Eventname { get; set; }

        [PersonalData]
        public string Coach { get; set; }

        [PersonalData]
        public string Location { get; set; }

        public virtual ICollection<ApplicationUser> Enrolled { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Eventdatetime { get; set; }
    }
}
