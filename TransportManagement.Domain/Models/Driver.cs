using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagement.Domain.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string LicenseNumber { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public ICollection<Order> Orders { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
