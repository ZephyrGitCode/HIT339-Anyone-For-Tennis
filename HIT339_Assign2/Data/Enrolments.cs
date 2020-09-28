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
    public class Enrolment
    {
        public int Id { get; set; }

        public int ScheduleId { get; set; }

        public string UserId { get; set; }

        public virtual Schedule Schedule { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
