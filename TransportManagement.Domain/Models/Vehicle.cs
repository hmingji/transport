using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Domain.Enums;

namespace TransportManagement.Domain.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public VehicleType Type { get; set; }
        public Driver Driver { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
