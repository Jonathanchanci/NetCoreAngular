using Dapper;
using NetCoreAngular.Models;
using NetCoreAngular.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NetCoreAngular.DataAccess
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionnString) : base(connectionnString)
        {

        }
        public IEnumerable<Supplier> SupplierPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page",page);
            parameters.Add("@rows", rows);

            using (var connection = new SqlConnection(_connerciontString))
            {
                return connection.Query<Supplier>("dbo.SupplierPagedList", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
