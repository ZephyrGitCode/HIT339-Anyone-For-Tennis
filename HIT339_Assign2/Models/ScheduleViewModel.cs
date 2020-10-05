using HIT339_Assign2.Areas.Identity.Data;
using HIT339_Assign2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIT339_Assign2.Models
{
    public class ScheduleViewModel
    {
        public List<Schedule> Schedules { get; set; }
        public List<ApplicationUser> Coachs { get; set; }
    }
}
