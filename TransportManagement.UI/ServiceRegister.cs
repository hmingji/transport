using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Application;
using TransportManagement.Database;
using TransportManagement.Domain.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection @this)
        {
            var serviceType = typeof(Service);
            var definedTypes = serviceType.Assembly.DefinedTypes;

            var services = definedTypes
                .Where(x => x.GetTypeInfo().GetCustomAttribute<Service>() != null);

            foreach (var service in services)
            {
                @this.AddTransient(service);
            }

            @this.AddTransient<IDriverManager, DriverManager>();
            @this.AddTransient<IVehicleManager, VehicleManager>();
            @this.AddTransient<IOrderManager, OrderManager>();

            return @this;
        }
    }
}
