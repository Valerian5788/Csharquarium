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
        // Interface for carnivorous species to define their eating behavior

        // Method for carnivorous species to eat other fish
        void Manger(Poisson repas, List<Poisson> poissons);
    }

}
