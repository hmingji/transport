using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Infrastructure;

namespace TransportManagement.Application.Orders
{
    [Service]
    public class DeleteOrder
    {
        private IOrderManager _orderManager;

        public DeleteOrder(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public Task<int> Do(int id)
        {
            return _orderManager.DeleteOrder(id);
        }
    }
}
