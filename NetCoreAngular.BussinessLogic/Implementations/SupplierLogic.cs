﻿using NetCoreAngular.BussinessLogic.Interfaces;
using NetCoreAngular.Models;
using NetCoreAngular.UnitOfWork;
using System.Collections.Generic;

namespace NetCoreAngular.BussinessLogic.Implementations
{
    public class SupplierLogic : ISupplierLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public bool Delete(Supplier supplier)
        {
            return _unitOfWork.Supplier.Delete(supplier);
        }

        public Supplier GetById(int id)
        {
            return _unitOfWork.Supplier.GetById(id);
        }

        public int Insert(Supplier supplier)
        {
            return _unitOfWork.Supplier.Insert(supplier);
        }

        public IEnumerable<Supplier> SupplierPagedList(int page, int rows, string searchTerm)
        {
            return _unitOfWork.Supplier.SupplierPagedList(page, rows, searchTerm);
        }

        public bool Update(Supplier supplier)
        {
            return _unitOfWork.Supplier.Update(supplier);
        }
    }
}
