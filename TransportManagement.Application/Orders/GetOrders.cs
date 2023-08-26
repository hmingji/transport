using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Infrastructure;

namespace TransportManagement.Application.Orders
{
    [Service]
    public class GetOrders
    {
        private IOrderManager _orderManager;

        public GetOrders(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public IEnumerable<OrderViewModel> Do() =>
            _orderManager.GetOrders(x => new OrderViewModel
            {
                Id = x.Id,
                OrderDate = x.OrderDate,
                OrderNumber = x.OrderNumber,
                DeliveryDate = x.DeliveryDate,
                DeliveryAddress = x.DeliveryAddress,
                DriverFullName = x.Driver.FullName,
            });

        public class OrderViewModel
        {
            public int Id { get; set; }
            public DateTime OrderDate { get; set; }
            public string OrderNumber { get; set; }
            public DateTime DeliveryDate { get; set; }
            public string DeliveryAddress { get; set; }
            public string DriverFullName { get; set; }
        }
    }
}
