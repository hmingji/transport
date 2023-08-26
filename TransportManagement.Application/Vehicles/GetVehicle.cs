using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Infrastructure;

namespace TransportManagement.Application.Vehicles
{
    [Service]
    public class GetVehicle
    {
        private IVehicleManager _vehicleManager;

        public GetVehicle(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        public VehicleViewModel Do(int id) =>
            _vehicleManager.GetVehicleById(id, x => new VehicleViewModel
            {
                Id = x.Id,
                PlateNumber = x.PlateNumber,
                Type = x.Type.ToString(),
                DateCreated = x.DateCreated,
                DateUpdated = x.DateUpdated,
            });

        public class VehicleViewModel
        {
            public int Id { get; set; }
            public string PlateNumber { get; set; }
            public string Type { get; set; }
            public DateTime DateCreated { get; set; }
            public DateTime DateUpdated { get; set; }
        }
    }
}
