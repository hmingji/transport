using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Enums;
using TransportManagement.Domain.Infrastructure;

namespace TransportManagement.Application.Vehicles
{
    [Service]
    public class UpdateVehicle
    {
        private IVehicleManager _vehicleManager;

        public UpdateVehicle(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        public Task<int> Do(Request request)
        {
            var vehicle = _vehicleManager.GetVehicleById(request.Id, x => x);
            vehicle.PlateNumber = request.PlateNumber;
            vehicle.Type = request.Type;
            vehicle.DateUpdated = DateTime.Now;

            return _vehicleManager.UpdateVehicle(vehicle);
        }

        public class Request
        {
            public int Id { get; set; }
            public string PlateNumber { get; set; }
            public VehicleType Type { get; set; }
        }
    }
}
