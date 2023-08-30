using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharquarium.Classes.Races;

namespace Csharquarium.Classes
{
    internal interface ICarnivore
    {
        void Manger(Poisson repas, List<Poisson> poissons);
    }

}
