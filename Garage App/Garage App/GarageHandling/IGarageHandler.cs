using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_App.GarageHandling
{
    internal interface IGarageHandler
    {
        public List<Garage> Garages { get; }

        public bool CheckIn(Garage garage);
        public string GetRegNr();
    }
}
