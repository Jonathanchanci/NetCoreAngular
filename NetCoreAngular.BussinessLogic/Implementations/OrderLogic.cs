﻿using NetCoreAngular.BussinessLogic.Interfaces;
using NetCoreAngular.Models;
using NetCoreAngular.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreAngular.BussinessLogic.Implementations
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork; 
        public bool Delete(Order order)
        {
            return _unitOfWork.Order.Delete(order);
        }

        public IEnumerable<OrderList> GetPaginatedOrder(int page, int rows)
        {
            return _unitOfWork.Order.getPaginatedOrder(page, rows);
        }

        public OrderList GetOrderById(int orderId)
        {
            return _unitOfWork.Order.GetOrderById(orderId);
        }

        public Order GetById(int orderId)
        {
            return _unitOfWork.Order.GetById(orderId);
        }

        public string GetOrderNumber(int orderId)
        {
            var list = _unitOfWork.Order.GetList();
            if (!list.Any()) return string.Empty;
            var record = list.FirstOrDefault(x => x.Id == orderId);
            return record.OrderNumber;
        }
    }
}
