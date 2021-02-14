using Dapper;
using NetCoreAngular.Models;
using NetCoreAngular.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NetCoreAngular.DataAccess
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<Customer> CustomerPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            using (var connection = new SqlConnection(_connerciontString))
            {
                return connection.Query<Customer>("dbo.CustomerPagedList"
                                                    , parameters
                                                    , commandType: System.Data.CommandType.StoredProcedure);
            }

        }
    }
}
