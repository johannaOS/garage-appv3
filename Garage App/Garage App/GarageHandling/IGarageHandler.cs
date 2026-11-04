using Garage_App.VehicleHandling;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Garage_App.GarageHandling
{
    public interface IGarageHandler
    {
        public List<Garage<IVehicle>> Garages { get; }

        public void CreateNewGarage(string Name, int spaces);

        //public bool CheckIn(Garage garage);
      //  public string GetRegNr();
    }
}
