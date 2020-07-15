using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class Repository : IRepository<UserRole>
    {
        private readonly EventsPortalDbContext context;
        private readonly DbSet<UserRole> entities;
        public Repository(EventsPortalDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<UserRole> GetAll()
        {
            return entities.AsEnumerable();
        }

        public UserRole Get(int id)
        {
            return entities.SingleOrDefault(p => p.Id == id);
        }
    }
}
