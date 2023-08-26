using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Infrastructure;
using TransportManagement.Domain.Models;

namespace TransportManagement.Application.Drivers
{
    [Service]
    public class CreateDriver
    {
        private IDriverManager _driverManager;

        public CreateDriver(IDriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public async Task<bool> Do(Request request)
        {
            var driver = new Driver
            {
                UserName = request.UserName,
                FullName = request.FullName,
                LicenseNumber = request.LicenseNumber,
                Vehicle = request.Vehicle,
            };

            var success = await _driverManager.CreateDriver(driver) > 0;

            if (success)
                return true;
            else
                return false;
        }

        public class Request
        {
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string LicenseNumber { get; set; }
            public Vehicle Vehicle { get; set; }
        }
    }
}
