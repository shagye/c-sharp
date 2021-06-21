using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hostel
{
    public class DBSeeder : DropCreateDatabaseIfModelChanges<HostelDBContext>
    {
        protected override void Seed(HostelDBContext context)
        {

            User user = new User()
            {
                Username = "Admin",
                Password = "admin",
                Type = "Admin",
                status = "Active",
            };
            Hostel hostel = new Hostel()
            {
                HostelName = "Huma Otel",
                HostelTitle = "HUMA",
                Email = "info@huma.com.tr",
                Phone = "0 (312) 330 00 00",
                City = "Muğla",
                Area = "Akyaka",
                Road = "2",
                House = "13",
                HostelLogo = "humalogo.png",
            };
            context.Users.Add(user);
            context.Hostels.Add(hostel);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}