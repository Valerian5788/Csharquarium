using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes
{
    internal interface IHermaOpport
    {
        // Interface for hermaphroditic species to define reproduction and sex change behavior

        // Method for hermaphroditic species to reproduce
        Poisson SeReproduire(Poisson homme, Poisson femme);

        // Method for hermaphroditic species to change their sex
        void ChangerSexe(Poisson poisson);
    }

}
