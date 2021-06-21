using Microsoft.EntityFrameworkCore;
using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Data
{
   public class ProjectAppDbContext : DbContext
    {

        public ProjectAppDbContext(DbContextOptions<ProjectAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
