using Project.Core.Repositories;
using Project.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Repositories
{
    public class UoW : IUoW
    {
        private readonly ProjectAppDbContext db;

        public IConsultantsRepository ConsultantsRepository { get; }

        public UoW(ProjectAppDbContext db)
        {
            this.db = db;
            ConsultantsRepository = new ConsultantsRepository(db);
        }

        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
