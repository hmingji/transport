using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Infrastructure;
using TransportManagement.Domain.Models;

namespace TransportManagement.Database
{
    public class OrderManager : IOrderManager
    {
        private ApplicationDbContext _ctx;

        public OrderManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<int> CreateOrder(Order order)
        {
            _ctx.Orders.Add(order);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteOrder(int id)
        {
            var order = _ctx.Orders.FirstOrDefault(x => x.Id == id);
            _ctx.Orders.Remove(order);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> UpdateOrder(Order Order)
        {
            _ctx.Orders.Update(Order);

            return _ctx.SaveChangesAsync();
        }

        public IEnumerable<TResult> GetOrders<TResult>(Func<Order, TResult> selector)
        {
            return _ctx.Orders
                .Include(x => x.Driver)
                .Select(selector)
                .ToList();
        }

        public TResult GetOrderById<TResult>(int id, Func<Order, TResult> selector)
        {
            return _ctx.Orders
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }
    }
}
