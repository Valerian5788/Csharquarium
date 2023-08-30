using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes.Races
{
    // Déclaration de la classe Carpe qui hérite de la classe Poisson et implémente l'interface iHerbivore
    internal class Carpe : Poisson, IHerbivore, IMonosexue
    {
        // Constructeur de la classe Carpe qui appelle le constructeur de la classe de base (Poisson)
        public Carpe(string name, bool isMale) : base(name, isMale)
        {
            Race = "Carpe";
            IsOccuped = false;
        }
    }
}