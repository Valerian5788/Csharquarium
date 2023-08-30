using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes.Races
{
    // Déclaration de la classe Bar qui hérite de la classe Poisson et implémente l'interface iCarnivore
    internal class Bar : Poisson, IHerbivore, IHermaAge
    {
        // Constructeur de la classe Bar qui appelle le constructeur de la classe de base (Poisson)
        public Bar(string name, bool isMale) : base(name, isMale)
        {
            Race = "Bar";
            IsOccuped = false;
            // Aucune autre initialisation requise pour le moment
        }
        // Méthode pour changer le sexe du poisson
        public void ChangerSexe()
        {
            // Inversion simple du sexe
            IsMale = !IsMale;
        }
    }
}
