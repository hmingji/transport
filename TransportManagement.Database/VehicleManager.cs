using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Infrastructure;
using TransportManagement.Domain.Models;

namespace TransportManagement.Database
{
    public class VehicleManager : IVehicleManager
    {
        private ApplicationDbContext _ctx;

        public VehicleManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<int> CreateVehicle(Vehicle vehicle)
        {
            _ctx.Vehicles.Add(vehicle);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteVehicle(int id)
        {
            var vehicle = _ctx.Vehicles.FirstOrDefault(x => x.Id == id);
            _ctx.Vehicles.Remove(vehicle);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> UpdateVehicle(Vehicle vehicle)
        {
            _ctx.Vehicles.Update(vehicle);

            return _ctx.SaveChangesAsync();
        }

        public IEnumerable<TResult> GetVehicles<TResult>(Func<Vehicle, TResult> selector)
        {
            return _ctx.Vehicles
                .Select(selector)
                .ToList();
        }

        public IEnumerable<TResult> GetVehiclesWithoutDriver<TResult>(Func<Vehicle, TResult> selector)
        {
            return _ctx.Vehicles
                .Include(x => x.Driver)
                .Where(x => x.Driver == null)
                .Select(selector)
                .ToList();
        }

        public TResult GetVehicleById<TResult>(int id, Func<Vehicle, TResult> selector)
        {
            return _ctx.Vehicles
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }
    }
}
