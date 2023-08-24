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

        // Implémentation de la méthode SeReproduire de l'interface IMonosexue
        Poisson IMonosexue.SeReproduire(Poisson homme, Poisson femme)
        {
            Noms nom = new Noms();
            string name = nom.GetNom();
            bool sexe = nom.GetSexe();
            Poisson newPoisson = new Thon(name, sexe); // Créer un nouvel objet de type thon
            Console.WriteLine($"Le miracle de la vie ! {homme.Name} et {femme.Name} ont eu un enfant : {name}");
            return newPoisson; // Retourner le nouveau poisson créé
        }
    }

}
