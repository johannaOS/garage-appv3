using Garage_App.VehicleHandling;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Garage_App.GarageHandling
{
    public class Garage<T> : IEnumerable<T> where T: IVehicle   
    {
        public int Id { get; }
        public int Spaces { get; }
        //private List<Vehicle> CheckedInVehicles = new List<Vehicle>();
        private List<T> _checkedInVehicles = new List<T>(); 
        public string? Name { get; set; }
        public Garage(string? name, int spaces)
        {
            if (spaces <= 0) throw new ArgumentException("Fel: Garaget måste innehålla fler än 0 platser");
            Spaces = spaces;
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Fel: Garaget måste ha ett namn!");
            Name = name;
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine($"| Du har skapat ett garage med namn \"{Name}\" som innehåller {Spaces} parkeringsplatser. |");
            Console.WriteLine("-------------------------------------------------------------------------------\n");
        }
        // Generic version, required by IEnumerable<T>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _checkedInVehicles.GetEnumerator();
        }
        // Non-generic version, required by IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
        public int GetAvailableSpaces(bool print = true)
        {
            int occupiedSpaces = _checkedInVehicles.Count;
            if (print)
                Console.WriteLine($"Det finns {Spaces - occupiedSpaces} av {Spaces} lediga parkeringsplatser. ");
            return Spaces - occupiedSpaces;
        }

    /*    public void CheckInVehicle(IVehicle vehicle)
        {
            if (vehicle is null)
                throw new ArgumentException("Vehicle cannot be null.");
            //kolla att fordonet inte redan finns
            int index = -1;
            if (!SearchByRegNr(vehicle.RegNr, ref index)) //fordonet finns inte i garaget
            {
                _checkedInVehicles.Add(vehicle);
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine($"| Din {vehicle.Type} är incheckad på parkeringsplats {_checkedInVehicles.IndexOf(vehicle)}. |");
                Console.WriteLine("-------------------------------------------------------------\n");
            }
            else
                Console.WriteLine($"!! Det här fordonet är redan registrerat på plats {index}!!\n");
        }*/

        public void CheckOut()
        {
            if (GetAvailableSpaces(false) == Spaces)
                throw new ArgumentException($"Garaget {Name} är tomt!");
            //Get vehicle registration No.
            Console.WriteLine("Ange registreringsnumret på fordonet du vill checka ut:");
            string? regNo = (Console.ReadLine() ?? "").Trim().ToUpper().Replace(" ", "");
            while (String.IsNullOrEmpty(regNo))
            {
                Console.WriteLine("Ange ett giltigt registreringsnummer!");
                regNo = (Console.ReadLine() ?? "").Trim().ToUpper().Replace(" ", "");
            }
            //Checka ut fordonet
            int matchIndex = -1;

            if (SearchByRegNr(regNo, ref matchIndex))
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"| Din {_checkedInVehicles[matchIndex].Type} med regNr {_checkedInVehicles[matchIndex].RegNr} har blivit utcheckat från {Name} |");
                Console.WriteLine("-----------------------------------------------------------------\n");
                _checkedInVehicles.RemoveAt(matchIndex);
            }
            else
            {
                Console.WriteLine($"Det här fordonet finns inte i {Name}");
            }

        }
        public bool SearchByRegNr(string regNr, ref int index)
        {
            regNr = regNr.ToUpper();
            //Search for vehicle in garage
            bool match = false;
            for (int i = 0; i < _checkedInVehicles.Count; i++)
            {
                    if (regNr == _checkedInVehicles[i].RegNr)
                    {
                        index = i;
                        match = true;
                        return match;
                    }
            }
            return match;
        }
        public void ListParkedVehicles()
        {
            GetAvailableSpaces();
            int[] countVehicleTypes = new int[5];
            foreach (var vehicle in _checkedInVehicles) {
                    switch (vehicle.Type)
                    {
                        case "Motorcykel":
                            countVehicleTypes[0]++;
                            break;
                        case "Flygplan":
                            countVehicleTypes[1]++;
                            break;
                        case "Bil":
                            countVehicleTypes[2]++;
                                break;
                        case "Buss":
                            countVehicleTypes[3]++;
                            break;
                        case "Båt":
                            countVehicleTypes[4]++;
                            break;
                        default:
                            break;

                    }
            }
            Console.WriteLine($"{Name} innehåller:\nMotorcyklar: {countVehicleTypes[0]}\nFlygplan: {countVehicleTypes[1]}\nBilar: {countVehicleTypes[2]}\nBussar: {countVehicleTypes[3]}\nBåtar: {countVehicleTypes[4]}\n");


        }

  /*      public List<Vehicle> SearchInRegNr(string _regNr)
        {
            if (_checkedInVehicles.Count == 0)
                throw new ArgumentException($"Det finns inga fordon i {Name}");
            // Kolla matchning
            var ResultList = new List<Vehicle>();
            foreach (Vehicle v in _checkedInVehicles)
            {
                    if (v.RegNr.Contains(_regNr))
                        ResultList.Add(v);
            }
            return ResultList;
        }*/

   /*     public List<Vehicle> SearchColor(string userInput)
        {
            if (_checkedInVehicles.Count == 0)
                throw new ArgumentException($"Det finns inga fordon i {Name}");

            // Kolla matchning
            var ResultList = new List<Vehicle>();
            foreach (Vehicle v in _checkedInVehicles)
            {
                    if (v.Color.Contains(userInput))
                        ResultList.Add(v);
            }
            return ResultList;
        }*/
       

    }
}
