using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Enums;
using TransportManagement.Domain.Infrastructure;
using TransportManagement.Domain.Models;

namespace TransportManagement.Application.Vehicles
{
    [Service]
    public class CreateVehicle
    {
        private IVehicleManager _vehicleManager;

        public CreateVehicle(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        public class Request
        {
            public string PlateNumber { get; set; }
            public VehicleType Type { get; set; }
        }

        public async Task<bool> Do(Request request)
        {
            var vehicle = new Vehicle
            {
                PlateNumber = request.PlateNumber,
                Type = request.Type,
            };

            var success = await _vehicleManager.CreateVehicle(vehicle) > 0;

            if (success)
                return true;
            else
                return false;
        }
    }
}
