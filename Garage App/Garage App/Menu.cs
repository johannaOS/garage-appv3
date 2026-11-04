using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Garage_App.GarageHandling;
namespace Garage_App
{
    public class Menu
    {
        private List<string> _menuOptions = new();
        public string? WelcomeMessage { get; set; }
        public int NrMenuOptions { get; set;  }
        public required List<string> MenuOptions { 
            get => _menuOptions;
            set
            {
                if (value == null)
                    throw new ArgumentException("MenuOptions cannot be null!");
                else
                    _menuOptions = value;
            } 
        }

        public void DisplayOptions(bool prompt = true)
        {
            if (prompt)
                Console.WriteLine("Vad vill du göra?");
            foreach (string option in MenuOptions)
            {
                Console.Write(option);
            }
        } 
    }

    public class Main : Menu
    {
        
    }
}
