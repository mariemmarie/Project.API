using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Data
{
    public class SeedData
    {

        public static async Task InitAsync(IServiceProvider services)
        {
            using (var db = new ProjectAppDbContext(services.GetRequiredService<DbContextOptions<ProjectAppDbContext>>()))
            {
                if (db.Consultants.Any())
                {
                    return;
                }

                var consultants = GetConsultants();

                await db.AddRangeAsync(consultants);
                await db.SaveChangesAsync();

            }
        }

        private static List<Consultant> GetConsultants()
        {
            var consultants = new List<Consultant>();

            for (int i = 0; i < 25; i++)
            {
            var fake = new Faker("fr");
                var consultant = new Consultant
                {
                    Nom = fake.Person.FirstName,
                    Prenom = fake.Person.LastName,
                    Email = fake.Internet.Email(),
                    Telephone = fake.Phone.PhoneNumber()
                };
                consultants.Add(consultant);

            }
            return consultants;
        }
    }
}
