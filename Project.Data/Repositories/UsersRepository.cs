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

    [Route("api/users")]
    public class UsersRepository : IUsersRespository
    {
        private readonly ProjectAppDbContext db;

        public UsersRepository (ProjectAppDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(User user)
        {
            await db.Users.AddAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await db.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        [Route("GetUserById")]

        public async Task<User> GetUser(int id)
        {
            return await db.Users.FindAsync(id);
        }
        [HttpDelete("{id}")]
        [Route("DeleteUser")]

        public void Remove(User user)
        {
            db.Remove(user);
        }

        public async Task<bool> SaveAsync()
        {
            return (await db.SaveChangesAsync()) >= 0;
        }
    }
}
