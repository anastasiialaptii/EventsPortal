using Core.Entities;
using System.Collections.Generic;

namespace Service
{
    public interface IRoleService
    {
        IEnumerable<Role> GetProduct();
        Role GetProduct(int id);
    }
}
