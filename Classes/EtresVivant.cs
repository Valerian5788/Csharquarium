using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes
{
    internal class EtresVivant
    {
        public int Pv = 10;
        public int age = 0;
        public void MourirPoisson(Poisson poisson, List<Poisson> poissons)
        {
               poissons.Remove(poisson);
               Console.WriteLine($"{poisson.Name} est mort de vieillesse, Paix à son ame");
        }
        public void MourirAlgue(Algues algue, List<Algues> algues)
        {
                algues.Remove(algue);
                Console.WriteLine($"Ironie du sort, une Algue vient de mourir de vieillesse");
        }
    }
}
