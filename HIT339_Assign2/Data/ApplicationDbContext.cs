﻿using System;
using System.Collections.Generic;
using System.Text;
using HIT339_Assign2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HIT339_Assign2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Schedule> Schedule { get; set; }

        public DbSet<Enrolment> Enrolment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.Entity<Item>().Property(b => b.Postdate).HasDefaultValueSql("getdate()");
            //builder.Entity<Schedule>().Property(m => m.Eventdatetime).HasDefaultValueSql("getdate()");
        }
    }
}
