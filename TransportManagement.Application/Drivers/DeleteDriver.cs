using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Infrastructure;

namespace TransportManagement.Application.Drivers
{
    [Service]
    public class DeleteDriver
    {
        private IDriverManager _driverManager;

        public DeleteDriver(IDriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public Task<int> Do(int id)
        {
            return _driverManager.DeleteDriver(id);
        }
    }
}
