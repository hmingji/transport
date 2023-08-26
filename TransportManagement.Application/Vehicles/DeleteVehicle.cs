using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Infrastructure;

namespace TransportManagement.Application.Vehicles
{
    [Service]
    public class DeleteVehicle
    {
        private IVehicleManager _vehicleManager;

        public DeleteVehicle(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        public Task<int> Do(int id)
        {
            return _vehicleManager.DeleteVehicle(id);
        }
    }
}
