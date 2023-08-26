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
    public class DriverManager : IDriverManager
    {
        private ApplicationDbContext _ctx;

        public DriverManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<int> CreateDriver(Driver driver)
        {
            _ctx.Drivers.Add(driver);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteDriver(int id)
        {
            var driver = _ctx.Drivers.FirstOrDefault(x => x.Id == id);
            _ctx.Drivers.Remove(driver);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> UpdateDriver(Driver driver)
        {
            _ctx.Drivers.Update(driver);

            return _ctx.SaveChangesAsync();
        }

        public IEnumerable<TResult> GetDriversWithOrders<TResult>(Func<Driver, TResult> selector)
        {
            return _ctx.Drivers
                .Include(x => x.Orders)
                .OrderBy(x => x.Orders.Min(y => y.DeliveryDate))
                .Select(selector)
                .ToList();
        }

        public IEnumerable<TResult> GetDriversWithVehicle<TResult>(Func<Driver, TResult> selector)
        {
            return _ctx.Drivers
                .Include(x => x.Vehicle)
                .Select(selector)
                .ToList();
        }

        public IEnumerable<TResult> GetDriversWithoutVehicle<TResult>(Func<Driver, TResult> selector)
        {
            return _ctx.Drivers
                .Include(x => x.Vehicle)
                .Where(x => x.Vehicle == null)
                .Select(selector)
                .ToList();
        }

        public TResult GetDriverById<TResult>(int id, Func<Driver, TResult> selector)
        {
            return _ctx.Drivers
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }
    }
}
