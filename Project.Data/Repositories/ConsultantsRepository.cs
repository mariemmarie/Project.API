using Microsoft.AspNetCore.Mvc;
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
    [Route("api/consultants")]
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

        [HttpGet("{id}")]
        [Route("GetConsultantById")]

        public async Task<Consultant> GetConsultant(int id)
        {
          return await db.Consultants.FindAsync(id);
        }
        [HttpDelete("{id}")]
        [Route("DeleteConsultant")]

        public void Remove(Consultant consultant)
        {
            db.Remove(consultant);
        }

        public async Task<bool> SaveAsync()
        {
            return (await db.SaveChangesAsync()) >= 0;
        }

        [HttpPost]
        [Route("InsertConsultant")]
        public void PostConsultant(Consultant consultant)
        {
            

          
        }

        [HttpPost]
        [Route("UpdateConsultant")]
        public void PutConsultant(Consultant consultant)
        {


        }
    }
}
