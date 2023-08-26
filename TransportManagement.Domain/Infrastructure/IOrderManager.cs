using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Models;

namespace TransportManagement.Domain.Infrastructure
{
    public interface IOrderManager
    {
        Task<int> CreateOrder(Order order);
        Task<int> DeleteOrder(int id);
        Task<int> UpdateOrder(Order order);

        TResult GetOrderById<TResult>(int id, Func<Order, TResult> selector);
        IEnumerable<TResult> GetOrders<TResult>(Func<Order, TResult> selector);
    }
}
