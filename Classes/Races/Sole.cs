using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes.Races
{
    // Déclaration de la classe Sole qui hérite de la classe Poisson et implémente l'interface iHerbivore
    internal class Sole : Poisson, IHerbivore, IHermaOpport
    {
        // Constructeur de la classe Sole qui appelle le constructeur de la classe de base (Poisson)
        public Sole(string name, bool isMale) : base(name, isMale)
        {
            Race = "Sole";
            IsOccuped = false;
        }
        // Méthode pour changer le sexe du poisson
        public void ChangerSexe()
        {
            // Inversion simple du sexe
            IsMale = !IsMale;
        }
    }
}
