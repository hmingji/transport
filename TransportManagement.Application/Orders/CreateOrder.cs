using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Infrastructure;
using TransportManagement.Domain.Models;

namespace TransportManagement.Application.Orders
{
    public class CreateOrder
    {
        private IOrderManager _orderManager;

        public CreateOrder(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public async Task<bool> Do(Request request)
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                OrderNumber = request.OrderNumber,
                DeliveryDate = request.DeliveryDate,
                DeliveryAddress = request.DeliveryAddress,
                Driver = request.Driver,
            };

            var success = await _orderManager.CreateOrder(order) > 0;

            if (success)
                return true;

            return false;
        }

        public class Request
        {
            public string OrderNumber { get; set; }
            public DateTime DeliveryDate { get; set; }
            public string DeliveryAddress { get; set; }
            public Driver Driver { get; set; }
        }
    }
}
