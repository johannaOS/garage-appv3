using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_App.GarageHandling
{
    internal class GarageHandler : IGarageHandler
    {
        public List<Garage> Garages { get; }

        public bool CheckIn(Garage garage)
        {
            int availableSpaces = garage.GetAvailableSpaces();
            if (availableSpaces > 0)
            {
                Console.WriteLine("Vilket typ av fordon vill du checka in?\n1: Motorcykel\t2: Flygplan\t3: Bil\t4: Buss\t5: Båt\t0: Avbryt"); //fyll på här när nya Vehicleklasser skapats
                string userChoice;
                while (true)
                {
                    userChoice = (Console.ReadLine() ?? "").Trim();
                    if (userChoice == "0")
                        return false;
                    else if (new string[] { "1", "2", "3", "4", "5" }.Contains(userChoice))
                    {
                        try
                        {
                            garage.CheckInVehicle(
                            CreateVehicle(userChoice, garage)
                            );
                            return true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return false;
                        }
                    }
                    else
                        Console.WriteLine("Ange ett giltigt val!");
                }
            }
            else
                throw new ArgumentException("Det här garaget är fullt!");
        }

        static Vehicle CreateVehicle(string choice, Garage garage)
        {
            switch (choice)
            {
                case "1": //motorcykel
                    {
                        string regNr;
                        try
                        {
                            regNr = ValidateRegNr(garage);
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException(ex.Message);
                        }
                        string color = ValidateColor();
                        int? nrOfWheels = ValidateNrOfWheels();

                        //instanciera en ny motorcykel
                        try
                        {
                            var motorcycle = new MotorCycle(regNr, color, nrOfWheels);
                            return motorcycle;
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException(ex.Message);
                        }
                    }
                case "2": //flygplan
                    {
                        string regNr;
                        try
                        {
                            regNr = ValidateRegNr(garage);
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException(ex.Message);
                        }
                        string color = ValidateColor();
                        double length = ValidateLength();

                        try
                        {
                            var airplane = new Airplane(regNr, color, length);
                            return airplane;
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException(ex.Message);
                        }
                    }
                case "3": //bil
                    {
                        string regNr;
                        try
                        {
                            regNr = ValidateRegNr(garage);
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException(ex.Message);
                        }
                        string color = ValidateColor();

                        try
                        {
                            var car = new Car(regNr, color);
                            return car;
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException(ex.Message);
                        }
                    }
                case "4": //buss
                    {
                        string regNr;
                        try
                        {
                            regNr = ValidateRegNr(garage);
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException(ex.Message);
                        }
                        string color = ValidateColor();

                        try
                        {
                            var bus = new Bus(regNr, color);
                            return bus;
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException(ex.Message);
                        }
                    }
                case "5": //båt
                    {
                        string regNr;
                        try
                        {
                            regNr = ValidateRegNr(garage);
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException(ex.Message);
                        }
                        string color = ValidateColor();

                        try
                        {
                            var boat = new Boat(regNr, color);
                            return boat;
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException(ex.Message);
                        }
                    }
                default:
                    break;
            }
            throw new ArgumentException("Det här fordonet finns redan i garaget!");
        }
        static string ValidateRegNr(Garage garage)
        {
            Console.Write("Ange registreringsnummer (obligatoriskt): ");
            string regNr = GetRegNr();
            //Check that _regNr is unique (in garage)
            int dummyIndex = -1;
            if (garage.SearchByRegNr(regNr, ref dummyIndex))
                throw new ArgumentException("Det här fordonet finns redan i garaget!");
            else
                return regNr;

        }
        public string GetRegNr()
        {
            string _regNr = (Console.ReadLine() ?? "").Trim().Replace(" ", "").ToUpper();
            while (String.IsNullOrEmpty(_regNr) || _regNr.Length > 12)
            {
                Console.WriteLine("Du måste ange ett giltigt registreringsnummer!");
                _regNr = (Console.ReadLine() ?? "").Trim().Replace(" ", "").ToUpper();
            }
            return _regNr;
        }
        static string ValidateColor()
        {
            Console.Write("Ange färg (obligatoriskt): ");
            while (true)
            {
                string color = (Console.ReadLine() ?? "").Trim().Replace(" ", "").ToLower();
                try
                {
                    if (String.IsNullOrEmpty(color) || color.Length > 200)
                        throw new ArgumentException("Du måste ange en giltig färg!");
                    return color;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        static int? ValidateNrOfWheels()
        {
            Console.Write("Ange antal hjul (tryck 0 för att hoppa över denna): ");
            int nrOfwheels;
            while (true)
            {
                string wheels = (Console.ReadLine() ?? "").Trim().Replace(" ", "");
                if (wheels == "0")
                    return null;
                if (int.TryParse(wheels, out nrOfwheels) && nrOfwheels > 1 && nrOfwheels < 11)
                    return nrOfwheels;
                else
                    Console.WriteLine("Du måste ange ett giltigt antal hjul!");
            }
        }
        static double ValidateLength()
        {
            Console.Write("Ange längd på fordonet (obligatorisk): ");
            double length;
            while (true)
            {
                string input = (Console.ReadLine() ?? "").Trim().Replace(" ", "");
                if (double.TryParse(input, out length) && length > 1 && length < 100)
                    return length;
                else
                    Console.WriteLine("Du måste ange en giltig längd!");
            }
        }

    }
}
