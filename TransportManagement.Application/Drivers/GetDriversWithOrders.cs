using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Infrastructure;

namespace TransportManagement.Application.Drivers
{
    [Service]
    public class GetDriversWithOrders
    {
        private IDriverManager _driverManager;

        public GetDriversWithOrders(IDriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public IEnumerable<DriverViewModel> Do() =>
            _driverManager.GetDriversWithOrders(x => new DriverViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
                FullName = x.FullName,
                OrderCount = x.Orders.Count,
            });

        public class DriverViewModel
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string FullName { get; set; }
            public int OrderCount { get; set; }
        }
    }
}
