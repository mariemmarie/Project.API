using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Repositories
{
    public interface IUsersRespository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int Id_User);
        void Remove(User user);
        Task<bool> SaveAsync();
        Task AddAsync(User user);
    }
}
