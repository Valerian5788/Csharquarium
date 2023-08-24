using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes
{
    internal interface IMonosexue
    {
        // Interface for species with single sex that can reproduce

        // Method for monosexual species to reproduce
        Poisson SeReproduire(Poisson homme, Poisson femme);
    }

}
