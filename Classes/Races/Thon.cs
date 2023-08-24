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
        public void Manger(Poisson repas)
        {
            // Le thon mange un autre poisson
            Console.WriteLine($"{Name} a croqué {repas.Name}.");
            repas.Pv -= 4; // Réduire les points de vie du poisson repas
            Pv += 4; // Augmenter les points de vie du thon
        }


    }

}
