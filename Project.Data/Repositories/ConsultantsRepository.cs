using Microsoft.EntityFrameworkCore;
using Project.Core.Entities;
using Project.Core.Repositories;
using Project.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Repositories
{
  public  class ConsultantsRepository : IConsultantsRepository
    {
        private readonly ProjectAppDbContext db;

        public ConsultantsRepository(ProjectAppDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(Consultant consultant)
        {
            await db.Consultants.AddAsync(consultant);
        }

        public async Task<IEnumerable<Consultant>> GetAllConsultants()
        {
           return await db.Consultants.ToListAsync();
        }

        public async Task<Consultant> GetConsultant(int id)
        {
          return await db.Consultants.FindAsync(id);
        }

        public void Remove(Consultant consultant)
        {
            db.Remove(consultant);
        }

        public async Task<bool> SaveAsync()
        {
            return (await db.SaveChangesAsync()) >= 0;
        }
    }
}
