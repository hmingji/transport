using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Infrastructure;
using TransportManagement.Domain.Models;

namespace TransportManagement.Application.Orders
{
    [Service]
    public class UpdateOrder
    {
        private IOrderManager _orderManager;

        public UpdateOrder(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public Task<int> Do(Request request)
        {
            var order = _orderManager.GetOrderById(request.Id, x => x);
            order.OrderNumber = request.OrderNumber;
            order.DeliveryDate = request.DeliveryDate;
            order.DeliveryAddress = request.DeliveryAddress;
            order.Driver = request.Driver;

            return _orderManager.UpdateOrder(order);
        }

        public class Request
        {
            public int Id { get; set; }
            public string OrderNumber { get; set; }
            public DateTime DeliveryDate { get; set; }
            public string DeliveryAddress { get; set; }
            public Driver Driver { get; set; }
        }
    }
}
