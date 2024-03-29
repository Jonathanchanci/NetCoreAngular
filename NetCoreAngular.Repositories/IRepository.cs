﻿using System.Collections.Generic;

namespace NetCoreAngular.Repositories
{
    public interface IRepository<T> where T: class
    {
        bool Delete(T entity);
        bool Update(T entity);
        int Insert(T entity);
        IEnumerable<T> GetList();
        T GetById(int id);
    }
}
