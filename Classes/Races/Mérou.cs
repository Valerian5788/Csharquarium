using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes.Races
{
    // Déclaration de la classe Mérou qui hérite de la classe Poisson et implémente l'interface iCarnivore
    internal class Mérou : Poisson, ICarnivore, IHermaAge
    {
        // Constructeur de la classe Mérou qui appelle le constructeur de la classe de base (Poisson)
        public Mérou(string name, bool isMale) : base(name, isMale)
        {
            Race = "Mérou";
            IsOccuped = false;
            // Aucune autre initialisation requise pour le moment
        }

    }


}
