using Garage_App.UI;
using Garage_App.GarageHandling;
using System;
using System.ComponentModel.Design;
using System.Xml.Linq;

IGarageHandler handler = new GarageHandler();
IUI ui = new ConsoleUI(handler);
ui.Run();


