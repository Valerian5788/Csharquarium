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

        // Méthode pour changer le sexe du poisson basée sur l'âge
        public void ChangerSexe(Poisson poisson)
        {
            // Inversion simple du sexe
            if (poisson.IsMale)
            {
                poisson.IsMale = false;
            }
            else
            {
                poisson.IsMale = true;
            }
        }

        // Implémentation de la méthode Manger de l'interface ICarnivore
        public void Manger(Poisson repas)
        {
            // Le mérou mange un autre poisson
            Console.WriteLine($"{Name} a croqué {repas.Name}.");
            repas.Pv -= 4; // Réduire les points de vie du poisson repas
            Pv += 4; // Augmenter les points de vie du mérou
        }

        // Implémentation de la méthode SeReproduire de l'interface IHermaAge
        Poisson IHermaAge.SeReproduire(Poisson homme, Poisson femme)
        {
            Noms nom = new Noms();
            string name = nom.GetNom();
            bool sexe = nom.GetSexe();
            Poisson newPoisson = new Mérou(name, sexe); // Créer un nouvel objet de type Bar
            Console.WriteLine($"Le miracle de la vie ! {homme.Name} et {femme.Name} ont eu un enfant : {name}");
            return newPoisson; // Retourner le nouveau poisson créé
        }
    }


}
