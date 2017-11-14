using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SecuringWebApi.Infrastructure;

namespace SecuringWebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SecuringWebApi.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SecuringWebApi.Infrastructure.ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var patient = new ApplicationUser()
            {
                UserName = "username_patient",
                EmailConfirmed = true
            };

            manager.Create(patient, "patientpassword");

            var doctor = new ApplicationUser()
            {
                UserName = "username_doctor",
                EmailConfirmed = true
            };

            manager.Create(doctor, "doctorpassword");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Doctor" });
                roleManager.Create(new IdentityRole { Name = "Patient" });
                roleManager.Create(new IdentityRole { Name = "Biller" });
            }

            var doctorUser = manager.FindByName("username_doctor");
            var patientUser = manager.FindByName("username_patient");

            manager.AddToRoles(doctorUser.Id, "Doctor");
            manager.AddToRoles(patientUser.Id, "Patient");
        }
    }
}
