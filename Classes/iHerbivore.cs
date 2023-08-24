using Csharquarium.Classes.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes
{
    internal interface IHerbivore
    {
        // Interface for herbivores to define their eating behavior
        void Manger(Algues repas);
    }

}
