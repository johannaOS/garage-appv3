using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_App.VehicleHandling
{
    public interface IVehicle
    {
        public string Type { get; }
        public string RegNr { get; }
        public string Color { get; set; }
        public int? ParkingSquaresNeeded { get; set; }
        public string? FuelType { get; set; }
    }
}
