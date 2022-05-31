using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.ToolsLibrary.ConsoleCore;

namespace Wifi.ToolsLibrary.TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var gebJahr = Tools.GetInputValue<int>("Bitte Geburtsjahr eingeben: ");
            //Console.WriteLine("Alter: " + (DateTime.Now.Year - gebJahr));

            //var length = Tools.GetInputValue<double>("Bitte Länge Seite 1eingeben: ");

            

            var myBook = Tools.GetInputValue<Book>("Bitte Buchdaten eingeben: ");
        }
    }
}
