using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Enums;
using TransportManagement.Domain.Infrastructure;

namespace TransportManagement.Application.Drivers
{
    [Service]
    public class GetDrivers
    {
        private IDriverManager _driverManager;

        public GetDrivers(IDriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public IEnumerable<DriverViewModel> Do() =>
            _driverManager.GetDriversWithVehicle(x => new DriverViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
                FullName = x.FullName,
                LicenseNumber = x.LicenseNumber,
                PlateNumber = x.Vehicle.PlateNumber,
                VehicleType = x.Vehicle.Type,
                DateCreated = x.DateCreated,
                DateUpdated = x.DateUpdated
            });

        public class DriverViewModel
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string LicenseNumber { get; set; }
            public string PlateNumber { get; set; }
            public VehicleType VehicleType { get; set; }
            public DateTime DateCreated { get; set; }
            public DateTime DateUpdated { get; set; }
        }
    }
}
