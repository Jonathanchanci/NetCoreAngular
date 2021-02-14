using Dapper.Contrib.Extensions;
using NetCoreAngular.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NetCoreAngular.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected string _connerciontString;
        public Repository(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{type.Name}"; };
            _connerciontString = connectionString;
        }
        public bool Delete(T entity)
        {
            using (var connection = new SqlConnection(_connerciontString))
            {
                return connection.Delete(entity);
            }
        }

        public T GetById(int id)
        {
            using (var connection = new SqlConnection(_connerciontString))
            {
                return connection.Get<T>(id);
            }
        }

        public IEnumerable<T> GetList()
        {
            using (var connection = new SqlConnection(_connerciontString))
            {
                return connection.GetAll<T>();
            }
        }

        public int Insert(T entity)
        {
            using (var connection = new SqlConnection(_connerciontString))
            {
                return (int)connection.Insert(entity);
            }
        }

        public bool Update(T entity)
        {
            using (var connection = new SqlConnection(_connerciontString))
            {
                return connection.Update(entity);
            }
        }
    }
}
