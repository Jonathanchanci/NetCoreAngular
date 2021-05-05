using NetCoreAngular.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAngular.BussinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        IEnumerable<OrderList> GetPaginatedOrder(int page, int rows);
        OrderList GetOrderById(int orderId);
        bool Delete(Order order);
        Order GetById(int orderId);
        string GetOrderNumber(int orderId);
    }
}
