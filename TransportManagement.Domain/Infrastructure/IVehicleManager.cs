using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Models;

namespace TransportManagement.Domain.Infrastructure
{
    public interface IVehicleManager
    {
        Task<int> CreateVehicle(Vehicle vehicle);
        Task<int> DeleteVehicle(int id);
        Task<int> UpdateVehicle(Vehicle vehicle);

        TResult GetVehicleById<TResult>(int id, Func<Vehicle, TResult> selector);
        IEnumerable<TResult> GetVehicles<TResult>(Func<Vehicle, TResult> selector);
        IEnumerable<TResult> GetVehiclesWithoutDriver<TResult>(Func<Vehicle, TResult> selector);
    }
}
