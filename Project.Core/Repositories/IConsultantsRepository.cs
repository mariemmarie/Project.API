using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Repositories
{
    public interface IConsultantsRepository
    {
        Task<IEnumerable<Consultant>> GetAllConsultants();
        Task<Consultant> GetConsultant(int id);
        void Remove(Consultant consultant);
        Task<bool> SaveAsync();
        Task AddAsync(Consultant consultant);

    }
}
