using Polymorphie.Core.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphie.Fahrzeuge
{
    internal class Motorrad : Fahrzeug
    {
        public override string Model => throw new NotImplementedException();

        public override SpeedUnit SpeedUnit => throw new NotImplementedException();

        public override void DisplayInfos()
        {
            throw new NotImplementedException();
        }

        public override void SpeedUp(Speed delta)
        {
            throw new NotImplementedException();
        }
    }
}
