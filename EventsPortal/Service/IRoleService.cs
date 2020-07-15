using Core.Entities;
using System.Collections.Generic;

namespace Service
{
    public interface IRoleService
    {
        IEnumerable<UserRole> GetProduct();
        UserRole GetProduct(int id);
    }
}
