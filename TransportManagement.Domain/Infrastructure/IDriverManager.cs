using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Models;

namespace TransportManagement.Domain.Infrastructure
{
    public interface IDriverManager
    {
        Task<int> CreateDriver(Driver driver);
        Task<int> DeleteDriver(int id);
        Task<int> UpdateDriver(Driver driver);

        TResult GetDriverById<TResult>(int id, Func<Driver, TResult> selector);
        IEnumerable<TResult> GetDriversWithVehicle<TResult>(Func<Driver, TResult> selector);
        IEnumerable<TResult> GetDriversWithOrders<TResult>(Func<Driver, TResult> selector);
        IEnumerable<TResult> GetDriversWithoutVehicle<TResult>(Func<Driver, TResult> selector);
    }
}
