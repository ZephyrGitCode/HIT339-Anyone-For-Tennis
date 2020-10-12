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

        public string Coach { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Enrolment> Enrolments { get; set; }

        public DateTime Eventdatetime { get; set; }

        public string Duration { get; set; }
    }
}
