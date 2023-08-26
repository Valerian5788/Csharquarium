using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes.Races
{
    // Déclaration de la classe Thon qui hérite de la classe Poisson et implémente l'interface iCarnivore
    internal class Thon : Poisson, ICarnivore, IMonosexue
    {
        // Constructeur de la classe Thon qui appelle le constructeur de la classe de base (Poisson)
        public Thon(string name, bool isMale) : base(name, isMale)
        {
            Race = "Thon";
            IsOccuped = false;
            // Aucune autre initialisation requise pour le moment
        }

        // Implémentation de la méthode Manger de l'interface ICarnivore
    }

}
