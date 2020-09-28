using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIT339_Assign2.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Schedule.Any())
                {
                    return;   // DB has been seeded
                }

                context.Schedule.AddRange(
                    new Schedule
                    {
                        Eventname = "Juniors",
                        Coach = "James",
                        Location = "Cas",
                        Eventdatetime = DateTime.Parse("2020-9-28")
                    },
                    new Schedule
                    {
                        Eventname = "Moderate",
                        Coach = "Nick",
                        Location = "Palmo",
                        Eventdatetime = DateTime.Parse("2020-9-28")
                    },
                    new Schedule
                    {
                        Eventname = "Seniors",
                        Coach = "Bob",
                        Location = "City",
                        Eventdatetime = DateTime.Parse("2020-9-28")
                    }

                );
                context.SaveChanges();

                if (context.Enrolment.Any())
                {
                    return;   // DB has been seeded
                }

                context.Enrolment.AddRange(
                    new Enrolment
                    {
                        ScheduleId = 1,
                        UserId = "e8644989-a44c-47ae-9f27-f7c21cd6af03"
                    },
                    new Enrolment
                    {
                        ScheduleId = 2,
                        UserId = "e8644989-a44c-47ae-9f27-f7c21cd6af03"
                    },
                    new Enrolment
                    {
                        ScheduleId = 3,
                        UserId = "e8644989-a44c-47ae-9f27-f7c21cd6af03"
                    },
                    new Enrolment
                    {
                        ScheduleId = 1,
                        UserId = "dfaf8ab1-03c8-4dde-a909-4320aa0bb5c6"
                    },
                    new Enrolment
                    {
                        ScheduleId = 3,
                        UserId = "dfaf8ab1-03c8-4dde-a909-4320aa0bb5c6"
                    }
                );
                context.SaveChanges();

            }
        }

    }
}
