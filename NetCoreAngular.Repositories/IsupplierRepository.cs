using NetCoreAngular.Models;
using System.Collections.Generic;

namespace NetCoreAngular.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> SupplierPagedList(int page, int rows, string searchTerm);
    }
}
