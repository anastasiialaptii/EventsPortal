using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository: IRepository<Role>
    {
        private readonly AppContext context;
       private readonly DbSet<Role> entities;
        public Repository(AppContext context)
        {
            this.context = context;
        }
        public IEnumerable<Role> GetAll()
        {
            return entities.AsEnumerable();
        }
        public Role Get(int id)
        {
            return entities.SingleOrDefault(p => p.Id== id);
        }
    }
}
